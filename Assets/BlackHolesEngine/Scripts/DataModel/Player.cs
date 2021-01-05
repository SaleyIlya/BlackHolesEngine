using System;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class Player
    {
        [JsonProperty("userId"), ShowInInspector]
        public Guid UserId { get; set; }
        [JsonProperty("inventory"), ShowInInspector]
        public Inventory Inventory { get; set; }
        [JsonProperty("money"), ShowInInspector]
        public Money Money { get; set; }
        [JsonProperty("gameProgress"), ShowInInspector]
        public GameProgress GameProgress { get; set; }
        [JsonProperty("currentPlayerLevel"), ShowInInspector]
        public float CurrentPlayerLevel { get; set; }
    }
}