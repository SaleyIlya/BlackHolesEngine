using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.Game;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class SpawnEnemySystem : IEcsRunSystem
    {
        private GameViewModel _gameViewModel;

        private EcsWorld _world;
        private EcsFilter<EnemyComponent, SpawnComponent> _filer;
        
        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            foreach (var index in _filer)
            {
                ref var spawn = ref _filer.Get2(index);

                spawn.TimeToSpawn -= Time.deltaTime;

                if (spawn.TimeToSpawn <= 0)
                {
                    SpawnEnemy(spawn.ObjectToSpawn, spawn.SpawnPoint);
                    _filer.GetEntity(index).Destroy();
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
            ref var moveComponent = ref enemyEntity.Get<MoveComponent>();
            
            moveComponent.Direction = new Vector2(0, -1);
            moveComponent.Speed = enemyGameObject.Speed;
        }
    }
}