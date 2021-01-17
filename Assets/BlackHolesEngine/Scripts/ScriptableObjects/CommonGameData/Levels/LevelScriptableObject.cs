using System;
using System.Collections.Generic;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "BlackHolesEngine/CommonObjects/Levels/Level", order = 0)]
    public class LevelScriptableObject : ScriptableObject
    {
        [SerializeField] private int levelInGameValuePrice;
        [SerializeField] private List<Vector2> enemyCoords;
        [SerializeField] private List<Vector2> wallsCoords;

        public LevelSettings GetLevelSettings()
        {
            return new LevelSettings
            {
                LevelInGameValuePrice = levelInGameValuePrice,
                EnemyCoords = enemyCoords,
                WallsCoords = wallsCoords
            };
        }
    }
}