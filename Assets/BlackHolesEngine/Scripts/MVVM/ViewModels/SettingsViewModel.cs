using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<bool> Sound { get; }
        public ReadOnlyReactiveProperty<bool> Vibration { get; }
        
        public ReactiveCommand ChangeSoundValue { get; }
        public ReactiveCommand ChangeVibrationValue { get; }
        
        public SettingsViewModel(IModel model) : base(model)
        {
            Sound = new ReadOnlyReactiveProperty<bool>(Model.Sound);
            Vibration = new ReadOnlyReactiveProperty<bool>(Model.Vibration);
            
            ChangeSoundValue = new ReactiveCommand();
            ChangeVibrationValue = new ReactiveCommand();

            ChangeSoundValue.Subscribe(_ => { Model.Sound.Value = !Model.Sound.Value; });
            ChangeVibrationValue.Subscribe(_ => { Model.Vibration.Value = !Model.Vibration.Value; });
        }
    }
}