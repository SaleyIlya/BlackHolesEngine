using System;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание магазинного предмета
    /// </summary>
    [System.Serializable]
    public class ShopItem
    {
        /// <summary>
        /// Айдишник для сопоставления со свойствами предмета и предметом в инвентаре
        /// </summary>
        [JsonProperty("itemId"), ShowInInspector]
        public Guid ItemId { get; set; }
        /// <summary>
        /// Стоимость предмета
        /// </summary>
        [JsonProperty("cost"), ShowInInspector]
        public Money Cost { get; set; }
    }
}