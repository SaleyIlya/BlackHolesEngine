using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.ECS.Systems;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ECS 
{
    sealed class GameEcsStartup : MonoBehaviour
    {
        public GamePrefabsScriptableObject GamePrefabsScriptableObject;
        [SerializeField] private Transform leftSpawnPoint;
        [SerializeField] private Transform rightSpawnPoint;
        
        [HideInInspector] public GameViewModel GameViewModel;
        [HideInInspector] public Camera Camera;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            if (leftSpawnPoint == null || rightSpawnPoint == null || GamePrefabsScriptableObject == null)
            {
                throw new ArgumentException("scene is not ready");
            }
            
            GamePrefabsScriptableObject.SetupSpawnPoints(leftSpawnPoint, rightSpawnPoint);
        }

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            Camera = Camera.main;
            GameViewModel = ServiceLocator.Default.Resolve<GameViewModel>();
            
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
                .Add(new SpawnEnemySystem())
                .Add(new SpawnBossSystem())
                
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