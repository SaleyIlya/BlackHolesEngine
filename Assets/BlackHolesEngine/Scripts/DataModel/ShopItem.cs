using System;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class ShopItem
    {
        [JsonProperty("itemId")]
        public Guid ItemId { get; set; }
        [JsonProperty("cost")]
        public Money Cost { get; set; }
    }
}