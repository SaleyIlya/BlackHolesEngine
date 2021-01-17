using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.ECS.Systems;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.GameViews;
using BlackHoles.ScriptableObjects;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS 
{
    sealed class GameEcsStartup : MonoBehaviour
    {
        public GamePrefabsScriptableObject GamePrefabsScriptableObject;
        [SerializeField] private Transform offsetPoint;
        [SerializeField] private DeathScreenView deathScreenView;
        [SerializeField] private VictoryScreenView victoryScreenView;
        
        
        [HideInInspector] public GameViewModel GameViewModel;
        [HideInInspector] public Camera Camera;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            if (offsetPoint == null ||
                GamePrefabsScriptableObject == null)
            {
                throw new ArgumentException("scene is not ready");
            }
            
            Camera = Camera.main;
            GameViewModel = ServiceLocator.Default.Resolve<GameViewModel>();
            
            GamePrefabsScriptableObject.SetupSpawnPoints(offsetPoint);

            GameViewModel.PlayerHp.Subscribe(hp =>
                {
                    if (hp > 0) return;
                    
                    GameViewModel.SetPauseCommand.Execute(true);
                    Instantiate(deathScreenView);
                })
                .AddTo(this);

            GameViewModel.BossDefeatCommand.Subscribe(_ =>
                {
                    GameViewModel.SetPauseCommand.Execute(true);
                    Instantiate(victoryScreenView);
                })
                .AddTo(this);
        }

        void Start () {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                .Add(new InitializeSystem())
                .Add(new PlayerControlSystem())
                .Add(new MoveSystem())
                .Add(new ShootSystem())
                .Add(new SpawnSystem())
                .Add(new DamageSystem())
                .Add(new RotationSystem())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(GamePrefabsScriptableObject)
                .Inject(GameViewModel)
                .Inject(Camera)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}