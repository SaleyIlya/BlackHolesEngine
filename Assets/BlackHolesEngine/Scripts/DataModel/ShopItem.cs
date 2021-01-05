using System;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class ShopItem
    {
        [JsonProperty("itemId"), ShowInInspector]
        public Guid ItemId { get; set; }
        [JsonProperty("cost"), ShowInInspector]
        public Money Cost { get; set; }
    }
}