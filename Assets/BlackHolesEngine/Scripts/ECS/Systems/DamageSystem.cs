using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.ECS.Components;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS.Systems
{
    public class DamageSystem : IEcsRunSystem
    {
        private GameViewModel _gameViewModel;
        private EcsWorld _world;
        
        private EcsFilter<TriggerComponent, BulletComponent, TransformComponent> _bullets;
        private EcsFilter<TriggerComponent, EnemyComponent, TransformComponent> _enemies;
        private EcsFilter<TriggerComponent, PlayerComponent, TransformComponent> _player;
        private EcsFilter<TriggerComponent, BossComponent, TransformComponent> _boss;
        
        public void Run()
        {
            ProcessPlayer();
            ProcessBoss();
            ProcessEnemies();
            ProcessBullets();
        }

        private void ProcessBullets()
        {
            foreach (var index in _bullets)
            {
                ref var trigger = ref _bullets.Get1(index);

                if (trigger.Trigger.TriggerEnter?.Any() == true)
                {
                    var obj = _bullets.Get3(index).Transform.gameObject;
                    var entity = _bullets.GetEntity(index);
                    entity.Destroy();
                    Object.Destroy(obj);
                }
            }
        }
        
        private void ProcessEnemies()
        {
            foreach (var index in _enemies)
            {
                ref var trigger = ref _enemies.Get1(index);

                if (trigger.Trigger.TriggerEnter?.Any() == true)
                {

                    if (trigger.Trigger.TriggerEnter?.Any(x => x.CompareTag("EnemyDestroyer")) == true)
                    {
                        _gameViewModel.PlayerGetDamageCommand.Execute(1);
                    }
                    
                    var obj = _enemies.Get3(index).Transform.gameObject;
                    var entity = _enemies.GetEntity(index);
                    entity.Destroy();
                    Object.Destroy(obj);
                }
            }
        }
        
        private void ProcessBoss()
        {
            foreach (var index in _boss)
            {
                ref var trigger = ref _boss.Get1(index);

                if (trigger.Trigger.TriggerEnter?.Any() == true)
                {
                    ref var boss = ref _boss.Get2(index);
                    boss.Hp--;

                    if (boss.Hp < 0)
                    {
                        var obj = _boss.Get3(index).Transform.gameObject;
                        var entity = _boss.GetEntity(index);
                        entity.Destroy();
                        Object.Destroy(obj);

                        _gameViewModel.BossDefeatCommand.Execute();
                    }
                }
            }
        }
        
        private void ProcessPlayer()
        {
            foreach (var index in _player)
            {
                ref var trigger = ref _player.Get1(index);

                if (trigger.Trigger.TriggerEnter?.Any() == true)
                {
                    _gameViewModel.PlayerGetDamageCommand.Execute(1);
                }
            }
        }
    }
}