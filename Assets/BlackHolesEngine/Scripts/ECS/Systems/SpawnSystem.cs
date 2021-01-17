using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.Game;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class SpawnSystem : IEcsRunSystem
    {
        private GameViewModel _gameViewModel;

        private EcsWorld _world;
        private EcsFilter<EnemyComponent, SpawnComponent> _enemies;
        private EcsFilter<SpawnComponent>.Exclude<EnemyComponent> _walls;
        
        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            foreach (var index in _enemies)
            {
                ref var spawn = ref _enemies.Get2(index);

                spawn.TimeToSpawn -= Time.deltaTime;

                if (spawn.TimeToSpawn <= 0)
                {
                    SpawnEnemy(spawn.ObjectToSpawn, spawn.SpawnPoint);
                    _enemies.GetEntity(index).Destroy();
                }
            }
            
            foreach (var index in _walls)
            {
                ref var spawn = ref _enemies.Get2(index);

                spawn.TimeToSpawn -= Time.deltaTime;

                if (spawn.TimeToSpawn <= 0)
                {
                    SpawnWall(spawn.ObjectToSpawn, spawn.SpawnPoint);
                    _enemies.GetEntity(index).Destroy();
                }
            }
        }

        private void SpawnEnemy(GameObject objToSpawn, Vector3 spawnPoint)
        {
            var enemyObject = Object.Instantiate(objToSpawn, spawnPoint, Quaternion.identity);
            var enemyGameObject = enemyObject.GetComponent<EnemyGameObject>();
            
            enemyGameObject.Init(_gameViewModel.EnemySprite);
            
            var enemyEntity = _world.NewEntity();

            enemyEntity.Get<EnemyComponent>();
            enemyEntity.Get<TransformComponent>().Transform = enemyObject.transform;
            enemyEntity.Get<TriggerComponent>().Trigger = enemyObject.GetComponent<TriggerDetector>();
            
            ref var moveComponent = ref enemyEntity.Get<MoveComponent>();
            moveComponent.Direction = new Vector2(0, -1);
            moveComponent.Speed = enemyGameObject.Speed;
        }
        
        private void SpawnWall(GameObject objToSpawn, Vector3 spawnPoint)
        {
            var wallObject = Object.Instantiate(objToSpawn, spawnPoint, Quaternion.identity);
            var wallGameObject = wallObject.GetComponent<EnemyGameObject>();
            
            wallGameObject.Init(_gameViewModel.BossSprite);
        }
    }
}