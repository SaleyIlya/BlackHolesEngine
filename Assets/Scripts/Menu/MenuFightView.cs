using System;
using System.Collections.Generic;
using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using UniRx;
using UnityEngine;

namespace BlackHoles.Menu
{
    public class MenuFightView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private SpriteRenderer enemySprite;
        [SerializeField] private SpriteRenderer bossSprite;
        [Space]
        [SerializeField] private List<Transform> playerShootTransforms;
        [Space]
        [SerializeField] private MenuBullet bulletPrefab;
        [Space]
        [SerializeField] private float shootDelay;

        private MarketplaceViewModel _viewModel;
        private Sprite _selectedBulletSprite;
        private int _currentBulletTransform;

        private Dictionary<Guid, Item> _skinItems;
        private Dictionary<Guid, Item> _weaponItems;
        private Dictionary<Guid, Item> _enemyItems;
        private Dictionary<Guid, Item> _bossItems;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<MarketplaceViewModel>();

            _skinItems = _viewModel.GameItems
                .Where(x => x.Value.ItemType == ItemType.Skin)
                .ToDictionary(x => x.Key, y => y.Value);
            _weaponItems = _viewModel.GameItems
                .Where(x => x.Value.ItemType == ItemType.Weapon)
                .ToDictionary(x => x.Key, y => y.Value);
            _enemyItems = _viewModel.GameItems
                .Where(x => x.Value.ItemType == ItemType.Enemy)
                .ToDictionary(x => x.Key, y => y.Value);
            _bossItems = _viewModel.GameItems
                .Where(x => x.Value.ItemType == ItemType.Wall)
                .ToDictionary(x => x.Key, y => y.Value);
            
            _viewModel.PlayerSelectedItems
                .ObserveAdd()
                .Subscribe(_ => SetupSprites())
                .AddTo(this);

            SetupSprites();
            
            Observable.Timer(TimeSpan.FromSeconds(shootDelay))
                .Repeat()
                .Subscribe(_ =>
                {
                    var newBullet = Instantiate(bulletPrefab, playerShootTransforms[_currentBulletTransform]);
                    newBullet.Init(_selectedBulletSprite);
                    _currentBulletTransform = (_currentBulletTransform + 1) % playerShootTransforms.Count;
                })
                .AddTo(this);
        }

        private void SetupSprites()
        {
            var selectedSkin = _viewModel.PlayerSelectedItems
                .FirstOrDefault(x => _skinItems.ContainsKey(x.ItemId));
            var selectedWeapon = _viewModel.PlayerSelectedItems
                .FirstOrDefault(x => _weaponItems.ContainsKey(x.ItemId));
            var selectedEnemy = _viewModel.PlayerSelectedItems
                .FirstOrDefault(x => _enemyItems.ContainsKey(x.ItemId));
            var selectedBoss = _viewModel.PlayerSelectedItems
                .FirstOrDefault(x => _bossItems.ContainsKey(x.ItemId));

            playerSprite.sprite = _skinItems[selectedSkin.ItemId].ItemIcon;
            enemySprite.sprite = _enemyItems[selectedEnemy.ItemId].ItemIcon;
            bossSprite.sprite = _bossItems[selectedBoss.ItemId].ItemIcon;
            _selectedBulletSprite = _weaponItems[selectedWeapon.ItemId].ItemIcon;
        }
    }
}