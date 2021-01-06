using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание прогресса игрока в игре
    /// </summary>
    [System.Serializable]
    public class GameProgress
    {
        /// <summary>
        /// Текущий уровень, пройденый игроком
        /// </summary>
        [JsonProperty("currentGameLevel"), ShowInInspector]
        public int CurrentGameLevel { get; set; }
    }
}