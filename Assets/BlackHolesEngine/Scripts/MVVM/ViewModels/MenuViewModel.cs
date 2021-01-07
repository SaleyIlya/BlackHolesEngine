using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<int> PlayerInGameValue { get; }
        public ReadOnlyReactiveProperty<int> PlayerPassedLevel { get; }
        public ReadOnlyReactiveProperty<bool> Sound { get; }
        public ReadOnlyReactiveProperty<bool>  Vibration { get; }

        public ReactiveCommand ChangeSoundValue { get; }
        public ReactiveCommand ChangeVibrationValue { get; }

        public MenuViewModel(IModel model) : base(model)
        {
            PlayerInGameValue = new ReadOnlyReactiveProperty<int>(Model.PlayerInGameValue);
            PlayerPassedLevel = new ReadOnlyReactiveProperty<int>(Model.PlayerPassedLevel);
            Sound = new ReadOnlyReactiveProperty<bool>(Model.Sound);
            Vibration = new ReadOnlyReactiveProperty<bool>(Model.Vibration);
            
            ChangeSoundValue = new ReactiveCommand();
            ChangeVibrationValue = new ReactiveCommand();

            ChangeSoundValue.Subscribe(_ => { Model.Sound.Value = !Model.Sound.Value; });
            ChangeVibrationValue.Subscribe(_ => { Model.Vibration.Value = !Model.Vibration.Value; });
        }
    }
}