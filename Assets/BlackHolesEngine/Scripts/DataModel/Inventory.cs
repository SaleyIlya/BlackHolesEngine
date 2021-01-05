using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class Inventory
    {
        [JsonProperty("playerItems")]
        public List<InventoryItem> PlayerItems { get; set; }
        [JsonProperty("selectedItems")]
        public List<InventoryItem> SelectedItems { get; set; }
    }
}