using System.Collections.Generic;
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
        /// <summary>
        /// Время появления врагов на уровне
        /// </summary>
        [JsonProperty("enemyTimings"), ShowInInspector]
        public List<float> EnemyTimings { get; set; }
        /// <summary>
        /// Время появления босса на уровне
        /// </summary>
        [JsonProperty("bossTimings"), ShowInInspector]
        public float BossTiming { get; set; }
    }
}