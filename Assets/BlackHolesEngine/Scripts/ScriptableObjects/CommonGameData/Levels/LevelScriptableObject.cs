using System;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "BlackHolesEngine/CommonObjects/Levels/Level", order = 0)]
    public class LevelScriptableObject : ScriptableObject
    {
        [SerializeField] private int levelInGameValuePrice;

        public LevelSettings GetLevelSettings()
        {
            return new LevelSettings
            {
                LevelInGameValuePrice = levelInGameValuePrice 
            };
        }
    }
}