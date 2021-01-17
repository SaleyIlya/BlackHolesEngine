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
            InitBossSpawner();
        }

        private void InitEnemiesSpawners()
        {
            var levelSettings = _gameViewModel.LevelSettings;

            foreach (var enemyTiming in levelSettings.EnemyTimings)
            {
                var newEnemySpawner = _world.NewEntity();
                newEnemySpawner.Get<EnemyComponent>();
                ref var spawn = ref newEnemySpawner.Get<SpawnComponent>();
                spawn.TimeToSpawn = enemyTiming;
                spawn.SpawnPoint = Vector2.Lerp(
                    _gamePrefabsScriptableObject.LeftSpawnPoint,
                    _gamePrefabsScriptableObject.RightSpawnPoint,
                    Random.Range(0f, 1f));
                spawn.ObjectToSpawn = _gamePrefabsScriptableObject.EnemyPrefab.gameObject;
            }
        }

        private void InitBossSpawner()
        {
            var bossSpawner = _world.NewEntity();
            bossSpawner.Get<BossComponent>();
            ref var spawn = ref bossSpawner.Get<SpawnComponent>();
            spawn.TimeToSpawn = _gameViewModel.LevelSettings.BossTiming;
            spawn.SpawnPoint = Vector2.Lerp(
                _gamePrefabsScriptableObject.LeftSpawnPoint,
                _gamePrefabsScriptableObject.RightSpawnPoint,
                0.5f);
            spawn.ObjectToSpawn = _gamePrefabsScriptableObject.BossPrefab.gameObject;
        }

        private void PlayerInit()
        {
            var playerGameObject = Object.Instantiate(_gamePrefabsScriptableObject.PlayerPrefab);
            playerGameObject.Init(_gameViewModel.PlayerSprite);
            
            var player = _world.NewEntity();
            player.Get<PlayerComponent>();
            player.Get<MoveComponent>().Speed = playerGameObject.Speed;
            player.Get<TransformComponent>().Transform = playerGameObject.transform;
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