using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class MenuViewModel
    {
        private LocalModel _model;

        public ReadOnlyReactiveProperty<Player> Player { get; }
        public ReadOnlyReactiveProperty<User> User { get; }
        
        public ReactiveCommand<string> ChangeNicknameCommand { get; }

        public MenuViewModel(LocalModel model) //todo
        {
            _model = model;
            Player = new ReadOnlyReactiveProperty<Player>(model.Player);
            User = new ReadOnlyReactiveProperty<User>(model.User);

            ChangeNicknameCommand = new ReactiveCommand<string>();
            ChangeNicknameCommand.Subscribe(nickname =>
            {
                _model.User.Value = new User
                {
                    Nickname = nickname,
                    UserId = _model.User.Value.UserId
                };
            });
        }
    }
}