using UnityEngine;

namespace BlackHoles.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Game/GamePrefabsScriptableObject", order = 0)]
    public class GamePrefabsScriptableObject : ScriptableObject
    {
        [SerializeField] private GameObject playerPrefab;

        public GameObject PlayerPrefab => playerPrefab;

    }
}