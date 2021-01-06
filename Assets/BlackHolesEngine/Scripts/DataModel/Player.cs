using System;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание персонажа игрока
    /// </summary>
    [System.Serializable]
    public class Player
    {
        /// <summary>
        /// Айди учетки игрока
        /// </summary>
        [JsonProperty("userId"), ShowInInspector]
        public Guid UserId { get; set; }
        /// <summary>
        /// Инвентарь игрока
        /// </summary>
        [JsonProperty("inventory"), ShowInInspector]
        public Inventory Inventory { get; set; }
        /// <summary>
        /// Денежное состояние игрока
        /// </summary>
        [JsonProperty("money"), ShowInInspector]
        public Money Money { get; set; }
        /// <summary>
        /// Игровой прогресс игрока
        /// </summary>
        [JsonProperty("gameProgress"), ShowInInspector]
        public GameProgress GameProgress { get; set; }
        /// <summary>
        /// Уровень игрока
        /// </summary>
        [JsonProperty("currentPlayerLevel"), ShowInInspector]
        public float CurrentPlayerLevel { get; set; }
    }
}