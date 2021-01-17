using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, RigidbodyComponent> _filter;
        private GameViewModel _gameViewModel;

        public void Run()
        {
            if (_gameViewModel.IsPause.Value)
            {
                return;
            }

            foreach (var index in _filter)
            {
                ref var move = ref _filter.Get1(index);
                ref var rigidbody = ref _filter.Get2(index);
                
                rigidbody.Rigidbody2D.velocity = move.Direction * move.Speed;
            }
        }
    }
}