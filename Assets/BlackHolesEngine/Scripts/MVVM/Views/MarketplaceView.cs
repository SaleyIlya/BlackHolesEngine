using System;
using System.Collections.Generic;
using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.Enums;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class MarketplaceView : MonoBehaviour
    {
        [SerializeField] private MarketplaceType marketplaceType;
        [Header("UI")]
        [SerializeField] private Button closeButton;
        [Space]
        [SerializeField] private TextMeshProUGUI goldValueText;
        [Space]
        [SerializeField] private Transform typeSelectorParentTransform;
        [SerializeField] private Transform itemsParentTableTransform;
        [Space]
        [SerializeField] private GameObject shopViewGameObject;
        [Header("Prefabs")]
        [SerializeField] private MarketplaceSelectorButtonView selectorButtonPrefab;
        [SerializeField] private ItemView itemPrefab;
        
        private MarketplaceViewModel _viewModel;
        
        private List<MarketplaceSelectorButtonView> _selectors;
        private List<ItemView> _currentItems;

        private ItemType _currentItemType;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<MarketplaceViewModel>();
            _selectors = new List<MarketplaceSelectorButtonView>();
            
            closeButton.onClick.AddListener(CloseWindow);
            
            _viewModel.PlayerInGameValue
                .Subscribe(x => { goldValueText.text = x.ToString(); })
                .AddTo(this);

            SetupSelectors();
            SelectFirstSelector();
            
            SetupMarketplace();

            FillTable();
        }

        private void SetupMarketplace()
        {
            switch (marketplaceType)
            {
                case MarketplaceType.Shop:
                    _viewModel.PlayerInventoryItems
                        .ObserveAdd()
                        .Subscribe(_ => RefillItemsTable())
                        .AddTo(this);
                    break;
                case MarketplaceType.Inventory:
                    _viewModel.PlayerSelectedItems
                        .ObserveAdd()
                        .Subscribe(_ => RefillItemsTable())
                        .AddTo(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SelectFirstSelector()
        {
            var firstSelector = _selectors.First();
            firstSelector.ChangeButtonState(true);
            _currentItemType = firstSelector.Type;
        }

        private void SetupSelectors()
        {
            var types = Enum.GetValues(typeof(ItemType));

            foreach (ItemType type in types)
            {
                var selectorButton = Instantiate(selectorButtonPrefab, typeSelectorParentTransform);
                selectorButton.Init(type, SelectorButtonAction);
                _selectors.Add(selectorButton);

                _currentItemType = type;
            }
        }

        private void SelectorButtonAction(MarketplaceSelectorButtonView currentButton)
        {
            foreach (var selector in _selectors)
            {
                selector.ChangeButtonState(false);
            }
            
            currentButton.ChangeButtonState(true);
            _currentItemType = currentButton.Type;
            RefillItemsTable();
        }

        private void RefillItemsTable()
        {
            ClearOldTable();
            FillTable();
        }

        private void FillTable()
        {
            switch (marketplaceType)
            {
                case MarketplaceType.Shop:
                    FillShopTable();
                    break;
                case MarketplaceType.Inventory:
                    FillInventoryTable();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void FillInventoryTable()
        {
            var gameItems = _viewModel.GameItems
                .Where(x => x.Value.ItemType == _currentItemType)
                .ToDictionary(x => x.Key, y => y.Value);
            var selectedItems = _viewModel.PlayerSelectedItems.ToList()
                .Where(x => gameItems.ContainsKey(x.ItemId))
                .ToDictionary(x => x.ItemId, y => y);
            var notSelectedItems = _viewModel.PlayerInventoryItems.ToList()
                .Where(x => gameItems.ContainsKey(x.ItemId) && !selectedItems.ContainsKey(x.ItemId))
                .ToDictionary(x => x.ItemId, y => y);

            foreach (var inventoryItem in selectedItems)
            {
                CreateItem(gameItems[inventoryItem.Key], inventoryItem.Value, true);
            }

            foreach (var inventoryItem in notSelectedItems)
            {
                CreateItem(gameItems[inventoryItem.Key], inventoryItem.Value, false);
            }
        }

        private void CreateItem(Item item, InventoryItem inventoryItem, bool isLocked)
        {
            var newItem = Instantiate(itemPrefab, itemsParentTableTransform);
            
            newItem.InitInventoryItem(item, inventoryItem, isLocked, _viewModel.SelectItemCommand.Execute);
        }

        private void FillShopTable()
        {
            var gameItems = _viewModel.GameItems
                .Where(x => x.Value.ItemType == _currentItemType)
                .ToDictionary(x => x.Key, y => y.Value);
            var inventoryItems = _viewModel.PlayerInventoryItems.ToList()
                .Where(x => gameItems.ContainsKey(x.ItemId))
                .ToDictionary(x => x.ItemId, y => y);
            var shopItems = _viewModel.ShopItems.ToList()
                .Where(x => gameItems.ContainsKey(x.Key) && !inventoryItems.ContainsKey(x.Key))
                .OrderBy(x => x.Value.Cost)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var shopItem in shopItems)
            {
                bool isLocked = shopItem.Value.Cost.InGameValue > _viewModel.PlayerInGameValue.Value;
                CreateItem(gameItems[shopItem.Key], shopItem.Value, isLocked);
            }
        }
        
        private void CreateItem(Item item, ShopItem shopItem, bool isLocked)
        {
            var newItem = Instantiate(itemPrefab, itemsParentTableTransform);
            
            newItem.InitShopItem(item, shopItem, isLocked, _viewModel.BuyItemCommand.Execute);
        }
        
        private void ClearOldTable()
        {
            var deleteQueue = new Queue<GameObject>();
            foreach (Transform itemTransform in itemsParentTableTransform)
            {
                deleteQueue.Enqueue(itemTransform.gameObject);
            }

            while (deleteQueue.Count > 0)
            {
                Destroy(deleteQueue.Dequeue());
            }
        }

        private void CloseWindow()
        {
            Destroy(shopViewGameObject);
        }
    }
}