using System;
using System.Collections.Generic;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class Item
    {
        [JsonProperty("itemId"), ShowInInspector]
        public Guid ItemId { get; set; }
        [JsonProperty("itemType"), ShowInInspector]
        public InventoryItemType ItemType { get; set; }
        [JsonProperty("startPropertyValue"), ShowInInspector]
        public float StartPropertyValue { get; set; }
        [JsonProperty("itemMaxLevel"), ShowInInspector]
        public int ItemMaxLevel { get; set; }
        [JsonProperty("propertyGrowValue"), ShowInInspector]
        public float PropertyGrowValue { get; set; }
        [JsonProperty("effects"), ShowInInspector]
        public List<ItemEffect> Effects { get; set; }
        [JsonProperty("name"), ShowInInspector]
        public string Name { get; set; }
        [JsonProperty("description"), ShowInInspector]
        public string Description { get; set; }
        [JsonIgnore, ShowInInspector]
        public Sprite ItemIcon { get; set; }
    }
}