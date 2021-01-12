using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class GameViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<bool> IsPause { get; }
        public ReadOnlyReactiveProperty<int> PlayerHp { get; }

        public ReactiveCommand<int> InitLevelCommand { get; }
        public ReactiveCommand<bool> SetPauseCommand { get; }
        
        public Sprite HpImageSprite { get; private set; }

        private readonly ReactiveProperty<bool> _isPause;
        private readonly ReactiveProperty<int> _playerHp;

        public GameViewModel(IModel model) : base(model)
        {
            _isPause = new ReactiveProperty<bool>(false);
            IsPause = new ReadOnlyReactiveProperty<bool>(_isPause);
            
            _playerHp = new ReactiveProperty<int>(Model.GameData.StartPlayerHp);
            PlayerHp = new ReadOnlyReactiveProperty<int>(_playerHp);

            InitLevelCommand = new ReactiveCommand<int>();
            SetPauseCommand = new ReactiveCommand<bool>();

            InitLevelCommand.Subscribe(InitNewLevelGameData);
            SetPauseCommand.Subscribe(isPause => _isPause.Value = isPause);
        }

        private void InitNewLevelGameData(int levelToInit)
        {
            var skinItems = Model.GameItems
                .Where(x => x.Value.ItemType == ItemType.Type1)  //todo selectType
                .ToDictionary(x => x.Key, y => y.Value);
            var selectedPlayerSkinId = Model.SelectedPlayerItems
                .FirstOrDefault(x => skinItems.Any(y => y.Key == x.ItemId))?
                .ItemId;
            HpImageSprite = skinItems[selectedPlayerSkinId.Value].ItemIcon;
        }
    }
}