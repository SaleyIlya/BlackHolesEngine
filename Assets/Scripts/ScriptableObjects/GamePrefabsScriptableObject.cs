using BlackHoles.Game;
using UnityEngine;

namespace BlackHoles.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Game/GamePrefabsScriptableObject", order = 0)]
    public class GamePrefabsScriptableObject : ScriptableObject
    {
        [SerializeField] private PlayerGameObject playerPrefab;
        [SerializeField] private BulletGameObject playerBulletPrefab;
        [SerializeField] private EnemyGameObject _enemyPrefab;

        private Vector2 _leftSpawnPoint;
        private Vector2 _rightSpawnPoint;
        
        public PlayerGameObject PlayerPrefab => playerPrefab;
        public BulletGameObject PlayerBulletPrefab => playerBulletPrefab;
        public EnemyGameObject EnemyPrefab => _enemyPrefab;

        public Vector2 LeftSpawnPoint => _leftSpawnPoint;
        public Vector2 RightSpawnPoint => _rightSpawnPoint;

        public void SetupSpawnPoints(Transform left, Transform right)
        {
            _leftSpawnPoint = left.position;
            _rightSpawnPoint = right.position;
        }
    }
}