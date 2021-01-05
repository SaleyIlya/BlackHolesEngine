using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class PlayerData
    {
        [JsonProperty("player")]
        public Player Player { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
    }
}