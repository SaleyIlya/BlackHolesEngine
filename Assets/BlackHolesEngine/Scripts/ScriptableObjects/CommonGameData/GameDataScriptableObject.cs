using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData
{
    [CreateAssetMenu(fileName = "GameData", menuName = "BlackHolesEngine/CommonObjects/GameData", order = 0)]
    public class GameDataScriptableObject : ScriptableObject
    {
        [SerializeField] private int startPlayerAttempts;
        [SerializeField] private int startPlayerHp;
        [SerializeField] private int finalLevelNumber;
        
        public GameData GetGameData()
        {
            return new GameData
            {
                StartPlayerAttempts = startPlayerAttempts,
                StartPlayerHp = startPlayerHp,
                FinalLevelNumber = finalLevelNumber
            };
        }
    }
}