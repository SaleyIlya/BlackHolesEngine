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
        [JsonProperty("ыtartPlayerHp"), ShowInInspector]
        public int StartPlayerHp { get; set; }
    }
}