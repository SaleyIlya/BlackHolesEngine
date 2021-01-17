﻿using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class ShootSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<ShootComponent> _filter;
        private GameViewModel _gameViewModel;

        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            foreach (var index in _filter)
            {
                ref var shootComponent = ref _filter.Get1(index);

                shootComponent.TimeSinceLastShoot += Time.deltaTime;
                
                if (shootComponent.TimeSinceLastShoot >= shootComponent.ShootDelay)
                {
                    var shootPoint = shootComponent.ShootPoints[Random.Range(0, shootComponent.ShootPoints.Length)];

                    var newBullet = Object.Instantiate(shootComponent.BulletPrefab, shootPoint.position,
                        Quaternion.identity);
                    newBullet.Init(_gameViewModel.PlayerBulletSprite);

                    var bulletEntity = _world.NewEntity();
                    bulletEntity.Get<TransformComponent>().Transform = newBullet.transform;
                    ref var bulletMove = ref bulletEntity.Get<MoveComponent>();
                    
                    bulletMove.Direction = shootComponent.ShootDirection;
                    bulletMove.Speed = newBullet.Speed;

                    shootComponent.TimeSinceLastShoot = 0;
                }
            }
        }
    }
}