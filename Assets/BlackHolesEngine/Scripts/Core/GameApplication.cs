using BlackHoles.BlackHolesEngine.Scripts.Core.Singleton;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.Core
{
    public class GameApplication : Singleton<GameApplication>
    {
        [SerializeField] private GameApplicationConfig gameApplicationConfig;

        private IModel _model;
        
        protected override void Awake()
        {
            base.Awake();

            //Todo add your implementation in BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation
            _model = new LocalModel();
            
            _model.Init(gameApplicationConfig);
            Bootstrapper.Bootstrapper.Init(_model);
        }
    }
}