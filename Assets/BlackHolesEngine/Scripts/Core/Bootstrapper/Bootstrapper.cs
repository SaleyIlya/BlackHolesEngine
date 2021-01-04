using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.Core.Bootstrapper
{
    public class Bootstrapper
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
            throw new System.NotImplementedException();
        }

        private static void RegisterViewModels(IModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}