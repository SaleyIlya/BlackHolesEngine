using System;
using System.Collections.ObjectModel;
using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.Factories;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class MarketplaceViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<int> PlayerInGameValue { get; }
        public IReadOnlyReactiveCollection<InventoryItem> PlayerInventoryItems { get; }
        public IReadOnlyReactiveCollection<InventoryItem> PlayerSelectedItems { get; }

        public ReadOnlyDictionary<Guid, Item> GameItems { get; }
        public ReadOnlyDictionary<Guid, ShopItem> ShopItems { get; }

        public ReactiveCommand<ShopItem> BuyItemCommand { get; }
        public ReactiveCommand<InventoryItem> SelectItemCommand { get; }

        public MarketplaceViewModel(IModel model) : base(model)
        {
            PlayerInGameValue = new ReadOnlyReactiveProperty<int>(Model.PlayerInGameValue);
            PlayerInventoryItems = Model.PlayerItems;
            PlayerSelectedItems = Model.SelectedPlayerItems;

            GameItems = Model.GameItems;
            ShopItems = Model.ShopItems;
            
            BuyItemCommand = new ReactiveCommand<ShopItem>();
            SelectItemCommand = new ReactiveCommand<InventoryItem>();

            BuyItemCommand.Subscribe(item =>
            {
                var inventoryItem = ItemFactory.ShopItemToInventory(item);
                var pursuedItem = Model.PlayerItems.FirstOrDefault(x => x.ItemId == item.ItemId);
                if (pursuedItem == null)
                {
                    Model.PlayerItems.Add(inventoryItem);
                }
                else
                {
                    inventoryItem.Count += pursuedItem.Count;
                    Model.PlayerItems.Remove(pursuedItem);
                    Model.PlayerItems.Add(inventoryItem);
                }
            });

            SelectItemCommand.Subscribe(item =>
            {
                var pursuedItem = Model.SelectedPlayerItems
                    .FirstOrDefault(x => GameItems[x.ItemId].ItemType == GameItems[item.ItemId].ItemType);
                if (pursuedItem != null)
                {
                    Model.SelectedPlayerItems.Remove(pursuedItem);
                }

                Model.SelectedPlayerItems.Add(item);
            });
        }
    }
}