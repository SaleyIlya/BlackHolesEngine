using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class Inventory
    {
        [JsonProperty("playerItems")]
        public List<InventoryItem> PlayerItems { get; set; }
        [JsonProperty("selectedItems")]
        public List<InventoryItem> SelectedItems { get; set; }
    }
}