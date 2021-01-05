using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class ShopItem
    {
        [JsonProperty("itemId")]
        public Guid ItemId { get; set; }
        [JsonProperty("cost")]
        public Money Cost { get; set; }
    }
}