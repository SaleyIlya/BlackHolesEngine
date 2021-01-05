using System.IO;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameApplicationConfig", menuName = "BlackHolesEngine/GameApplicationConfig", order = 0)]
    public class GameApplicationConfig : ScriptableObject 
    {
        [SerializeField] private string saveLoadPath;

        public string SaveLoadPath => Path.Combine(Application.persistentDataPath, saveLoadPath);
    }
}