using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService.Implementation;

namespace BlackHoles.BlackHolesEngine.Scripts.Core.Bootstrapper
{
    /// <summary>
    /// Класс, инициирующий сервислокатор
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Инициализация вьюмоделей в сервислокаторе
        /// </summary>
        /// <param name="model">проинициализированная модель</param>
        public static void InitViewModels(IModel model)
        {
            RegisterViewModels(model);
        }
        
        /// <summary>
        /// Инициализация сервисов в сервислокаторе
        /// </summary>
        public static void InitServices()
        {
            RegisterServices();
        }

        /// <summary>
        /// Регистрация необходимых сервисов тут
        /// </summary>
        private static void RegisterServices()
        {
            ServiceLocator.ServiceLocator.Default
                .Register<IModelLoadService>(new LocalModelLoadService());
        }

        /// <summary>
        /// Регистрация вьюмоделей тут
        /// </summary>
        /// <param name="model">проинициализированная модель</param>
        private static void RegisterViewModels(IModel model)
        {
            ServiceLocator.ServiceLocator.Default
                .Register(new MenuViewModel(model))
                .Register(new AdvViewModel(model))
                .Register(new SettingsViewModel(model))
                .Register(new MarketplaceViewModel(model));
        }
    }
}