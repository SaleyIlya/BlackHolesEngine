using System.IO;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameApplicationConfig", menuName = "BlackHolesEngine/GameApplicationConfig", order = 0)]
    public class GameApplicationConfig : ScriptableObject 
    {
        [SerializeField] private string playerDataPath;
        [SerializeField] private string playerSettingsPath;

        public string PlayerDataPath => Path.Combine(Application.persistentDataPath, playerDataPath);
        public string PlayerSettingsPath => Path.Combine(Application.persistentDataPath, playerSettingsPath);
    }
}