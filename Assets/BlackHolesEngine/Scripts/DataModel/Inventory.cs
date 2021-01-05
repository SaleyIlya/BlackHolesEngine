using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class Inventory
    {
        [JsonProperty("playerItems"), ShowInInspector]
        public List<InventoryItem> PlayerItems { get; set; }
        [JsonProperty("selectedItems"), ShowInInspector]
        public List<InventoryItem> SelectedItems { get; set; }
    }
}