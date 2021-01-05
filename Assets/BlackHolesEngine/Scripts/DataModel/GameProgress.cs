using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class GameProgress
    {
        [JsonProperty("currentGameLevel")]
        public int CurrentGameLevel { get; set; }
    }
}