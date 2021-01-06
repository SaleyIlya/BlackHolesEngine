using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Инвентарь игрока
    /// </summary>
    [System.Serializable]
    public class Inventory
    {
        /// <summary>
        /// Предметы, которые есть у игрока в наличии
        /// </summary>
        [JsonProperty("playerItems"), ShowInInspector]
        public List<InventoryItem> PlayerItems { get; set; }
        /// <summary>
        /// Выбранные игроком предметы
        /// </summary>
        [JsonProperty("selectedItems"), ShowInInspector]
        public List<InventoryItem> SelectedItems { get; set; }
    }
}