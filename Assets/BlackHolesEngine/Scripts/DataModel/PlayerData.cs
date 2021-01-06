using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Компиляция данных игрока, необходимых для сохранения/восстановления его игрового прогресса
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        /// <summary>
        /// Описание персонажа игрока
        /// </summary>
        [JsonProperty("player"), ShowInInspector]
        public Player Player { get; set; }
        /// <summary>
        /// Описание учетки игрока
        /// </summary>
        [JsonProperty("user"), ShowInInspector]
        public User User { get; set; }
    }
}