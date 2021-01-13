using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание параметров геймплея
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Начальный уровень здоровья игрока
        /// </summary>
        [JsonProperty("startPlayerHp"), ShowInInspector]
        public int StartPlayerHp { get; set; }
        /// <summary>
        /// Начальное кол-во попыток игрока
        /// </summary>
        [JsonProperty("startPlayerHp"), ShowInInspector]
        public int StartPlayerAttempts { get; set; }
    }
}