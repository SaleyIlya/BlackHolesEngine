using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, TransformComponent> _filter;
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
                ref var transform = ref _filter.Get2(index);
                
                transform.Transform.Translate(move.Direction * (move.Speed * Time.deltaTime));
            }
        }
    }
}