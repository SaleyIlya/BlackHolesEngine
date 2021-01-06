using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание предмета в инвентаре
    /// </summary>
    [System.Serializable]
    public class InventoryItem
    {
        /// <summary>
        /// Айдишник для сопоставления со свойствами предмета и предметом в магазине
        /// </summary>
        [JsonProperty("itemId"), ShowInInspector]
        public Guid ItemId { get; set; }
        /// <summary>
        /// Уровень предмета
        /// </summary>
        [JsonProperty("itemLevel"), ShowInInspector]
        public int ItemLevel { get; set; }
        /// <summary>
        /// Количество предметов
        /// </summary>
        [JsonProperty("count"), ShowInInspector]
        public int Count { get; set; }
    }
}