using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.Singleton;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService;
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

            // Add your implementation in BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation
            _model = new LocalModel();
            
            Bootstrapper.Bootstrapper.InitServices();
            _model.Init(gameApplicationConfig);
            Bootstrapper.Bootstrapper.InitViewModels(_model);
        }

        private void OnDestroy()
        {
            ServiceLocator.ServiceLocator.Default.Resolve<IModelLoadService>()
                .SavePlayerData(_model, gameApplicationConfig.SaveLoadPath);
        }
    }
}