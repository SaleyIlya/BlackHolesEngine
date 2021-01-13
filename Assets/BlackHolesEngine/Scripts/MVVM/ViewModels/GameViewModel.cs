﻿using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;
using UniRx;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels
{
    public class GameViewModel : ViewModel
    {
        public ReadOnlyReactiveProperty<bool> IsPause { get; }
        public ReadOnlyReactiveProperty<int> PlayerHp { get; private set; }
        public ReadOnlyReactiveProperty<int> PlayerAttempts { get; private set; }

        public ReactiveCommand<int> InitLevelCommand { get; }
        public ReactiveCommand<bool> SetPauseCommand { get; }
        public ReactiveCommand ChangePlayerAttemptCommand { get; }

        public Sprite HpImageSprite { get; private set; }

        private ReactiveProperty<bool> _isPause;
        private ReactiveProperty<int> _playerHp;
        private ReactiveProperty<int> _playerAttempts;

        public GameViewModel(IModel model) : base(model)
        {
            _isPause = new ReactiveProperty<bool>(false);
            IsPause = new ReadOnlyReactiveProperty<bool>(_isPause);

            InitLevelCommand = new ReactiveCommand<int>();
            SetPauseCommand = new ReactiveCommand<bool>();
            ChangePlayerAttemptCommand = new ReactiveCommand();

            InitLevelCommand.Subscribe(InitNewLevelGameData);
            SetPauseCommand.Subscribe(isPause =>
            {
                _isPause.Value = isPause;
            });
            ChangePlayerAttemptCommand.Subscribe(_ =>
            {
                _playerAttempts.Value -= 1;
            });
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
            
            _playerHp = new ReactiveProperty<int>(Model.GameData.StartPlayerHp);
            _playerAttempts = new ReactiveProperty<int>(Model.GameData.StartPlayerAttempts);
            
            PlayerAttempts = new ReadOnlyReactiveProperty<int>(_playerAttempts);
            PlayerHp = new ReadOnlyReactiveProperty<int>(_playerHp);
        }
    }
}