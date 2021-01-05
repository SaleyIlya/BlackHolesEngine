using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class Money
    {
        [JsonProperty("inGameValue"), ShowInInspector]
        public int InGameValue { get; set; }
        [JsonProperty("donateValue"), ShowInInspector]
        public int DonateValue { get; set; }
        [JsonProperty("energy"), ShowInInspector]
        public int Energy { get; set; }
    }
}