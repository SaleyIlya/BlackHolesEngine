using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class InitializeSystem : IEcsInitSystem
    {
        private GamePrefabsScriptableObject _gamePrefabsScriptableObject;
        private EcsWorld _world;
        
        public void Init()
        {
            var playerGameObject = Object.Instantiate(_gamePrefabsScriptableObject.PlayerPrefab);
            var player = _world.NewEntity();
            player.Get<PlayerComponent>();
            player.Get<MoveComponent>().Speed = 5;
            player.Get<ShootComponent>();
            player.Get<TransformComponent>().Transform = playerGameObject.transform;
        }
    }
}