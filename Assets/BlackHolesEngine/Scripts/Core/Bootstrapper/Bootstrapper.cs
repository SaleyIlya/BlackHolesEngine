﻿using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService.Implementation;

namespace BlackHoles.BlackHolesEngine.Scripts.Core.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void InitViewModels(IModel model)
        {
            RegisterViewModels(model);
        }
        
        public static void InitServices()
        {
            RegisterServices();
        }

        private static void RegisterServices()
        {
            ServiceLocator.ServiceLocator.Default
                .Register<IModelLoadService>(new LocalModelLoadService());
        }

        private static void RegisterViewModels(IModel model)
        {
            ServiceLocator.ServiceLocator.Default
                .Register(new MenuViewModel(model as LocalModel));
        }
    }
}