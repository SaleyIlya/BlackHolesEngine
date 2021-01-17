using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.Game;
using BlackHoles.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class InitializeSystem : IEcsInitSystem
    {
        private GamePrefabsScriptableObject _gamePrefabsScriptableObject;
        private EcsWorld _world;
        private GameViewModel _gameViewModel;
        
        public void Init()
        {
            PlayerInit();
            InitEnemiesSpawners();
            InitWallsSpawners();
        }

        private void InitEnemiesSpawners()
        {
            var levelSettings = _gameViewModel.LevelSettings;

            foreach (var enemyCoords in levelSettings.EnemyCoords)
            {
                var newEnemySpawner = _world.NewEntity();
                
                newEnemySpawner.Get<EnemyComponent>();
                
                ref var spawn = ref newEnemySpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = 1f;
                spawn.SpawnPoint = enemyCoords + _gamePrefabsScriptableObject.Offset;
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.EnemyPrefab.gameObject;
            }
        }
        
        private void InitWallsSpawners()
        {
            var levelSettings = _gameViewModel.LevelSettings;

            foreach (var wallCoord in levelSettings.WallsCoords)
            {
                var wallSpawner = _world.NewEntity();
                ref var spawn = ref wallSpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = 0f;
                spawn.SpawnPoint = wallCoord + _gamePrefabsScriptableObject.Offset;
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.WallPrefab.gameObject;
            }

            for (int i = -1; i < 5; i++)
            {
                var wallSpawner = _world.NewEntity();
                ref var spawn = ref wallSpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = 0f;
                spawn.SpawnPoint = new Vector2(i, 6) + _gamePrefabsScriptableObject.Offset;
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.WallPrefab.gameObject;
                
                wallSpawner = _world.NewEntity();
                spawn = ref wallSpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = 0f;
                spawn.SpawnPoint = new Vector2(i, -1) + _gamePrefabsScriptableObject.Offset;
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.WallPrefab.gameObject;
                
                wallSpawner = _world.NewEntity();
                spawn = ref wallSpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = 0f;
                spawn.SpawnPoint = new Vector2(-1, i + 1) + _gamePrefabsScriptableObject.Offset;
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.WallPrefab.gameObject;
                
                wallSpawner = _world.NewEntity();
                spawn = ref wallSpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = 0f;
                spawn.SpawnPoint = new Vector2(4, i + 1) + _gamePrefabsScriptableObject.Offset;
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.WallPrefab.gameObject;
            }
        }

        private void PlayerInit()
        {
            var playerPos = _gamePrefabsScriptableObject.Offset + new Vector2(3, 0);

            var playerGameObject =
                Object.Instantiate(_gamePrefabsScriptableObject.PlayerPrefab, playerPos, Quaternion.identity);
            playerGameObject.Init(_gameViewModel.PlayerSprite);
            
            var player = _world.NewEntity();
            player.Get<PlayerComponent>();
            player.Get<MoveComponent>().Speed = playerGameObject.Speed;
            player.Get<RigidbodyComponent>().Rigidbody2D = playerGameObject.GetComponent<Rigidbody2D>();
            player.Get<TriggerComponent>().Trigger = playerGameObject.GetComponent<TriggerDetector>();
            
            ref var shootComponent = ref player.Get<ShootComponent>();
            shootComponent.BulletPrefab = _gamePrefabsScriptableObject.PlayerBulletPrefab;
            shootComponent.ShootDelay = playerGameObject.ShootDelay;
            shootComponent.ShootPoints = playerGameObject.ShootPoints.ToArray();
            shootComponent.TimeSinceLastShoot = 0f;
            shootComponent.ShootDirection = new Vector2(0f, 1f);
        }
    }
}