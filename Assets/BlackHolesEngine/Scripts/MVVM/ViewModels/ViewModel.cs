using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public abstract class ViewModel
    {
        protected IModel Model;

        protected ViewModel(IModel model)
        {
            Model = model;
        }
    }
}