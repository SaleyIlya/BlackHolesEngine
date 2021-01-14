using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание уровня
    /// </summary>
    public class LevelSettings
    {
        /// <summary>
        /// Вознаграждение за прохождение уровня игроком
        /// </summary>
        [JsonProperty("levelInGameValuePrice"), ShowInInspector]
        public int LevelInGameValuePrice { get; set; }
    }
}