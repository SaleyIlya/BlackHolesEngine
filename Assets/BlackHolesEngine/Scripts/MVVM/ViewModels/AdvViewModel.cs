using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class AdvViewModel : ViewModel
    {
        public ReactiveCommand<Money> GetMoneyCommand { get; }

        public AdvViewModel(IModel model) : base(model)
        {
            GetMoneyCommand = new ReactiveCommand<Money>();

            GetMoneyCommand.Subscribe(money =>
            {
                Model.PlayerInGameValue.Value += money.InGameValue;
                Model.PlayerDonateValue.Value += money.DonateValue;
                Model.PlayerEnergy.Value += money.Energy;
            });
        }
    }
}