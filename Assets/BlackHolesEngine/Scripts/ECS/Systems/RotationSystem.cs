using System;
using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class RotationSystem : IEcsRunSystem
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
                var direction = _filter.Get1(index).Direction;
                var transform = _filter.Get2(index).Rigidbody2D.transform;

                if (Math.Abs(direction.y - 1f) < Mathf.Epsilon)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                if (Math.Abs(direction.y + 1f) < Mathf.Epsilon)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                }
                if (Math.Abs(direction.x - 1f) < Mathf.Epsilon)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, -90f);
                }
                if (Math.Abs(direction.x + 1f) < Mathf.Epsilon)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 90f);
                }
            }
        }
    }
}