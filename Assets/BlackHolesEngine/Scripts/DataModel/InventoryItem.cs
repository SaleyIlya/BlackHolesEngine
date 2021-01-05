using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class InventoryItem
    {
        [JsonProperty("itemId"), ShowInInspector]
        public Guid ItemId { get; set; }
        [JsonProperty("itemLevel"), ShowInInspector]
        public int ItemLevel { get; set; }
        [JsonProperty("count"), ShowInInspector]
        public int Count { get; set; }
    }
}