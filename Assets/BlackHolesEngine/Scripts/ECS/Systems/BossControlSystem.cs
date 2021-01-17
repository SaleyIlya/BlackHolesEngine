using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class BossControlSystem : IEcsRunSystem
    {
        private GameViewModel _gameViewModel;
        
        private EcsFilter<BossComponent, MoveComponent, TransformComponent> _filter;
        
        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            foreach (var index in _filter)
            {
                ref var boss = ref _filter.Get1(index);
                ref var move = ref _filter.Get2(index);
                ref var transform = ref _filter.Get3(index);

                Vector2 bossPosition = transform.Transform.position;
                var distToPoint = Vector2.Distance(boss.CurrentPointToMove, bossPosition);

                if (distToPoint <= 0.2f)
                {
                    var newPoint = new Vector2(Random.Range(boss.MaxLeftX, boss.MaxRightX), bossPosition.y);
                    var rowDirection = newPoint - bossPosition;
                    rowDirection.y = 0;
                    move.Direction = rowDirection.normalized;
                    boss.CurrentPointToMove = newPoint;
                }
            }
        }
    }
}