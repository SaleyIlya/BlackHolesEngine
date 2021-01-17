using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

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
        /// Координаты появления врагов на уровне
        /// </summary>
        [JsonProperty("enemyCoords"), ShowInInspector]
        public List<Vector2> EnemyCoords { get; set; }
        /// <summary>
        /// Координаты появления стен на уровне
        /// </summary>
        [JsonProperty("wallsCoords"), ShowInInspector]
        public List<Vector2> WallsCoords { get; set; }
    }
}