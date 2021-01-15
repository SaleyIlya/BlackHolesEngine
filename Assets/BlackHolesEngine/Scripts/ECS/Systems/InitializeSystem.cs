﻿using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
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
        }

        private void PlayerInit()
        {
            var playerGameObject = Object.Instantiate(_gamePrefabsScriptableObject.PlayerPrefab);
            playerGameObject.Init(_gameViewModel.PlayerSprite);
            
            var player = _world.NewEntity();
            player.Get<PlayerComponent>();
            player.Get<MoveComponent>().Speed = playerGameObject.Speed;
            player.Get<TransformComponent>().Transform = playerGameObject.transform;
            ref var shootComponent = ref player.Get<ShootComponent>();
            shootComponent.BulletPrefab = _gamePrefabsScriptableObject.PlayerBulletPrefab;
            shootComponent.ShootDelay = playerGameObject.ShootDelay;
            shootComponent.ShootPoints = playerGameObject.ShootPoints.ToArray();
            shootComponent.TimeSinceLastShoot = 0f;
            shootComponent.ShootDirection = new Vector2(0f, 1f);
        }
    }
}