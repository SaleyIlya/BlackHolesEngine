using BlackHoles.Game;
using UnityEngine;

namespace BlackHoles.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Game/GamePrefabsScriptableObject", order = 0)]
    public class GamePrefabsScriptableObject : ScriptableObject
    {
        [SerializeField] private PlayerGameObject playerPrefab;
        [SerializeField] private BulletGameObject playerBulletPrefab;

        public PlayerGameObject PlayerPrefab => playerPrefab;
        public BulletGameObject PlayerBulletPrefab => playerBulletPrefab;

    }
}