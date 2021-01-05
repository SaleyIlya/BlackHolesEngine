using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class Money
    {
        [JsonProperty("inGameValue")]
        public int InGameValue { get; set; }
        [JsonProperty("donateValue")]
        public int DonateValue { get; set; }
        [JsonProperty("energy")]
        public int Energy { get; set; }
    }
}