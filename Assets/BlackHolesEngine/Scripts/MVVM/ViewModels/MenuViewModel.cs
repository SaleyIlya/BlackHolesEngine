using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<int> PlayerDanateValue { get; }
        public ReadOnlyReactiveProperty<int> PlayerPassedLevel { get; }

        public MenuViewModel(IModel model) : base(model)
        {
            PlayerDanateValue = new ReadOnlyReactiveProperty<int>(Model.PlayerDonateValue);
            PlayerPassedLevel = new ReadOnlyReactiveProperty<int>(Model.PlayerPassedLevel);
        }
    }
}