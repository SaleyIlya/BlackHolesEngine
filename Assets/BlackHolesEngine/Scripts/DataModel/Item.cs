using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class Item
    {
        [JsonProperty("itemId")]
        public Guid ItemId { get; set; }
        [JsonProperty("itemType")]
        public InventoryItemType ItemType { get; set; }
        [JsonProperty("startPropertyValue")]
        public float StartPropertyValue { get; set; }
        [JsonProperty("itemMaxLevel")]
        public int ItemMaxLevel { get; set; }
        [JsonProperty("propertyGrowValue")]
        public float PropertyGrowValue { get; set; }
        [JsonProperty("effects")]
        public List<ItemEffect> Effects { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonIgnore]
        public Sprite ItemIcon { get; set; }
    }
}