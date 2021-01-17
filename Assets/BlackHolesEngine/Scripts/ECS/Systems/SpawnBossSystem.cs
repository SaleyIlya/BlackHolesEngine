using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.Game;
using BlackHoles.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class SpawnBossSystem : IEcsRunSystem
    {
        private GameViewModel _gameViewModel;
        private GamePrefabsScriptableObject _gamePrefabsScriptableObject;

        private EcsWorld _world;
        private EcsFilter<BossComponent, SpawnComponent> _filer;
        
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
                    SpawnBoss(spawn.ObjectToSpawn, spawn.SpawnPoint);
                    _filer.GetEntity(index).Destroy();
                }
            }
        }

        private void SpawnBoss(GameObject objToSpawn, Vector3 spawnPoint)
        {
            var bossObject = Object.Instantiate(objToSpawn, spawnPoint, Quaternion.identity);
            var bossGameObject = bossObject.GetComponent<BossGameObject>();
            
            bossGameObject.Init(_gameViewModel.BossSprite);
            
            var bossEntity = _world.NewEntity();

            ref var bossComponent = ref bossEntity.Get<BossComponent>().Hp;

            ref var shootComponent = ref bossEntity.Get<ShootComponent>();
            shootComponent.BulletPrefab = _gamePrefabsScriptableObject.PlayerBulletPrefab;
            shootComponent.ShootDelay = bossGameObject.ShootDelay;
            shootComponent.ShootPoints = bossGameObject.ShootPoints.ToArray();
            shootComponent.TimeSinceLastShoot = 0f;
            shootComponent.ShootDirection = new Vector2(0f, -1f);
            
            bossEntity.Get<TransformComponent>().Transform = bossObject.transform;
            ref var moveComponent = ref bossEntity.Get<MoveComponent>();
            
            moveComponent.Direction = new Vector2(0, -1);
            moveComponent.Speed = bossGameObject.Speed;
        }
    }
}