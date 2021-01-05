using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class InventoryItem
    {
        [JsonProperty("itemId")]
        public Guid ItemId { get; set; }
        [JsonProperty("itemLevel")]
        public int ItemLevel { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}