using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class GameViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<bool> IsPause { get; }
        public ReadOnlyReactiveProperty<int> PlayerHp { get; private set; }
        public ReadOnlyReactiveProperty<int> PlayerAttempts { get; private set; }

        public ReactiveCommand<int> PlayerGetDamageCommand { get; }
        public ReactiveCommand<int> InitLevelCommand { get; }
        public ReactiveCommand<bool> SetPauseCommand { get; }
        public ReactiveCommand ChangePlayerAttemptCommand { get; }
        public ReactiveCommand ResetPlayerHpCommand { get; }
        public ReactiveCommand FinishLevelCommand { get; }
        public ReactiveCommand BossDefeatCommand { get; }

        public LevelSettings LevelSettings { get; private set; }
        
        public Sprite PlayerSprite { get; private set; }
        public Sprite PlayerBulletSprite { get; private set; }
        public Sprite EnemySprite { get; private set; }
        public Sprite BossSprite { get; private set; }

        private ReactiveProperty<bool> _isPause;
        private ReactiveProperty<int> _playerHp;
        private ReactiveProperty<int> _playerAttempts;

        public GameViewModel(IModel model) : base(model)
        {
            _isPause = new ReactiveProperty<bool>(false);
            IsPause = new ReadOnlyReactiveProperty<bool>(_isPause);

            InitLevelCommand = new ReactiveCommand<int>();
            PlayerGetDamageCommand = new ReactiveCommand<int>();
            SetPauseCommand = new ReactiveCommand<bool>();
            ChangePlayerAttemptCommand = new ReactiveCommand();
            ResetPlayerHpCommand = new ReactiveCommand();
            FinishLevelCommand = new ReactiveCommand();
            BossDefeatCommand = new ReactiveCommand();

            InitLevelCommand.Subscribe(InitNewLevelGameData);
            SetPauseCommand.Subscribe(isPause =>
            {
                _isPause.Value = isPause;
            });
            ChangePlayerAttemptCommand.Subscribe(_ =>
            {
                _playerAttempts.Value -= 1;
            });
            ResetPlayerHpCommand.Subscribe(_ =>
            {
                _playerHp.Value = Model.GameData.StartPlayerHp;
            });
            PlayerGetDamageCommand.Subscribe(_ =>
            {
                _playerHp.Value -= 1;
            });
            FinishLevelCommand.Subscribe(_ =>
            {
                Model.PlayerInGameValue.Value += LevelSettings.LevelInGameValuePrice;
                Model.PlayerPassedLevel.Value++;
            });
        }

        private void InitNewLevelGameData(int levelToInit)
        {
            var skinItems = Model.GameItems
                .Where(x => x.Value.ItemType == ItemType.Skin)
                .ToDictionary(x => x.Key, y => y.Value);
            var selectedPlayerSkinId = Model.SelectedPlayerItems
                .FirstOrDefault(x => skinItems.Any(y => y.Key == x.ItemId))?
                .ItemId;
            var weaponItems = Model.GameItems
                .Where(x => x.Value.ItemType == ItemType.Weapon)
                .ToDictionary(x => x.Key, y => y.Value);
            var selectedWeaponSkinId = Model.SelectedPlayerItems
                .FirstOrDefault(x => weaponItems.Any(y => y.Key == x.ItemId))?
                .ItemId;
            var enemiesItems = Model.GameItems
                .Where(x => x.Value.ItemType == ItemType.Enemy)
                .ToDictionary(x => x.Key, y => y.Value);
            var selectedEnemySkinId = Model.SelectedPlayerItems
                .FirstOrDefault(x => enemiesItems.Any(y => y.Key == x.ItemId))?
                .ItemId;
            var bossesItems = Model.GameItems
                .Where(x => x.Value.ItemType == ItemType.Wall)
                .ToDictionary(x => x.Key, y => y.Value);
            var selectedBossSkinId = Model.SelectedPlayerItems
                .FirstOrDefault(x => bossesItems.Any(y => y.Key == x.ItemId))?
                .ItemId;
            
            PlayerSprite = skinItems[selectedPlayerSkinId.Value].ItemIcon;
            PlayerBulletSprite = weaponItems[selectedWeaponSkinId.Value].ItemIcon;
            EnemySprite = enemiesItems[selectedEnemySkinId.Value].ItemIcon;
            BossSprite = bossesItems[selectedBossSkinId.Value].ItemIcon;

            LevelSettings = Model.GetLevelSettings(levelToInit);

             _isPause.Value = false;
             
             _playerHp = new ReactiveProperty<int>(Model.GameData.StartPlayerHp);
            _playerAttempts = new ReactiveProperty<int>(Model.GameData.StartPlayerAttempts);
            
            PlayerAttempts = new ReadOnlyReactiveProperty<int>(_playerAttempts);
            PlayerHp = new ReadOnlyReactiveProperty<int>(_playerHp);
        }
    }
}