using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class GameProgress
    {
        [JsonProperty("currentGameLevel"), ShowInInspector]
        public int CurrentGameLevel { get; set; }
    }
}