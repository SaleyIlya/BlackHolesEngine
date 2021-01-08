using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<int> PlayerInGameValue { get; }
        public ReadOnlyReactiveProperty<int> PlayerPassedLevel { get; }

        public MenuViewModel(IModel model) : base(model)
        {
            PlayerInGameValue = new ReadOnlyReactiveProperty<int>(Model.PlayerInGameValue);
            PlayerPassedLevel = new ReadOnlyReactiveProperty<int>(Model.PlayerPassedLevel);
        }
    }
}