using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class PlayerControlSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, MoveComponent, TransformComponent> _filter;
        private GameViewModel _gameViewModel;
        private Camera _camera;
        
        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            var direction = new Vector2(0f, 0f);
            var screenMousePosition = Input.mousePosition;

            foreach (var index in _filter)
            {
                ref var move = ref _filter.Get2(index);
                ref var transform = ref _filter.Get3(index);
                
                if (Input.GetMouseButton(0))
                {
                    var playerScreenPoint = _camera.WorldToScreenPoint(transform.Transform.position);
                    var deltaRow = screenMousePosition - playerScreenPoint;
                    var delta = deltaRow.normalized;
                    direction = new Vector2(delta.x, delta.y);
                }

                move.Direction = direction;
            }
        }
    }
}