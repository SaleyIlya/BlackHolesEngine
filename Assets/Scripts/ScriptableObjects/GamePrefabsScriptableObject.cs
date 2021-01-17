using BlackHoles.Game;
using UnityEngine;

namespace BlackHoles.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Game/GamePrefabsScriptableObject", order = 0)]
    public class GamePrefabsScriptableObject : ScriptableObject
    {
        [SerializeField] private PlayerGameObject playerPrefab;
        [SerializeField] private BulletGameObject playerBulletPrefab;
        [SerializeField] private BulletGameObject enemyBulletPrefab;
        [SerializeField] private EnemyGameObject enemyPrefab;
        [SerializeField] private WallGameObject wallPrefab;

        private Vector2 _offset;
        
        public PlayerGameObject PlayerPrefab => playerPrefab;
        public BulletGameObject PlayerBulletPrefab => playerBulletPrefab;
        public BulletGameObject EnemyBulletPrefab => enemyBulletPrefab;
        public EnemyGameObject EnemyPrefab => enemyPrefab;
        public WallGameObject WallPrefab => wallPrefab;

        public Vector2 Offset => _offset;

        public void SetupSpawnPoints(Transform offset)
        {
            _offset = offset.position;
        }
    }
}