using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class GameProgress
    {
        [JsonProperty("currentGameLevel")]
        public int CurrentGameLevel { get; set; }
    }
}