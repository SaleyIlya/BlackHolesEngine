using System;
using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class PlayerControlSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, MoveComponent, ShootComponent> _filter;
        private GameViewModel _gameViewModel;
        private Camera _camera;
        
        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            var direction = new Vector2(0f, 0f);
            var dx = Input.GetAxisRaw("Horizontal");
            var dy = Input.GetAxisRaw("Vertical");
            
            if (Math.Abs(dx) > Mathf.Epsilon)
            {
                direction.x = dx;
            }
            else if (Math.Abs(dy) > Mathf.Epsilon)
            {
                direction.y = dy;
            }

            direction = direction.normalized;

            foreach (var index in _filter)
            {
                ref var move = ref _filter.Get2(index);
                ref var shoot = ref _filter.Get3(index);

                move.Direction = direction;
                
                if (direction != Vector2.zero)
                {
                    shoot.ShootDirection = direction;
                }
            }
        }
    }
}