using System;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class Player
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("inventory")]
        public Inventory Inventory { get; set; }
        [JsonProperty("money")]
        public Money Money { get; set; }
        [JsonProperty("gameProgress")]
        public GameProgress GameProgress { get; set; }
        [JsonProperty("currentPlayerLevel")]
        public float CurrentPlayerLevel { get; set; }
    }
}