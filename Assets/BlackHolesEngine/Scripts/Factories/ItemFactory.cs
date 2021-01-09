using BlackHoles.BlackHolesEngine.Scripts.DataModel;

namespace BlackHoles.BlackHolesEngine.Scripts.Factories
{
    public static class ItemFactory
    {
        public static InventoryItem ShopItemToInventory(ShopItem shopItem)
        {
            return new InventoryItem
            {
                Count = 1,
                ItemId = shopItem.ItemId,
                ItemLevel = 0
            };
        }
    }
}