using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class PlayerData
    {
        [JsonProperty("player"), ShowInInspector]
        public Player Player { get; set; }
        [JsonProperty("user"), ShowInInspector]
        public User User { get; set; }
    }
}