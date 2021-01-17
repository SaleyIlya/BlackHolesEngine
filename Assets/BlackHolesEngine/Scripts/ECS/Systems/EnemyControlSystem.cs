using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class EnemyControlSystem : IEcsRunSystem
    {
        private GameViewModel _gameViewModel;
        
        private EcsFilter<EnemyComponent, MoveComponent, ShootComponent> _filter;
        
        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            foreach (var index in _filter)
            {
                ref var enemy = ref _filter.Get1(index);
                ref var move = ref _filter.Get2(index);
                ref var shoot = ref _filter.Get3(index);

                enemy.TimeToChangeDirection -= Time.deltaTime;

                if (enemy.TimeToMove <= 0)
                {
                    var axis = Random.Range(0, 2);
                    var direction = Random.Range(0, 2);
                    var value = direction > 0 ? 1 : -1;
                    
                    if (axis > 0)
                    {
                        move.Direction = new Vector2(0, value);
                    }
                    else
                    {
                        move.Direction = new Vector2(value, 0);
                    }

                    enemy.TimeToMove = Random.Range(0.5f, 1.5f);
                    enemy.TimeToChangeDirection = Random.Range(0.5f, 1.5f);

                    shoot.ShootDirection = move.Direction;
                    
                    continue;
                }

                if (enemy.TimeToChangeDirection <= 0)
                {
                    move.Direction = Vector2.zero;
                    enemy.TimeToMove -= Time.deltaTime;
                }
            }
        }
    }
}