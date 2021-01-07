﻿using System;
using System.Collections.Generic;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService;
using Newtonsoft.Json;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation
{
    public class LocalModel : IModel
    {
        private ReactiveProperty<Player> _player;
        private ReactiveProperty<User> _user;
        private ReactiveProperty<int> _playerPassedLevel;
        private ReactiveProperty<int> _playerDonateValue;

        public ReactiveProperty<Player> Player => _player;
        public ReactiveProperty<User> User => _user;
        public ReactiveProperty<int> PlayerPassedLevel => _playerPassedLevel;

        public ReactiveProperty<int> PlayerDonateValue => _playerDonateValue;

        private GameApplicationConfig _applicationConfig;
        private IModelLoadService _modelLoadService;
        
        public void Init(GameApplicationConfig gameApplicationConfigScriptableObject)
        {
            _applicationConfig = gameApplicationConfigScriptableObject;
            ServiceLocator.Default.Resolve<IModelLoadService>().LoadPlayerData(this, _applicationConfig.SaveLoadPath);
        }

        public string GetPlayerData()
        {
            var obj = new PlayerData
            {
                Player = _player.Value,
                User = _user.Value
            };
            return JsonConvert.SerializeObject(obj);
        }

        public void InitPlayerData(string data)
        {
            var obj = JsonConvert.DeserializeObject<PlayerData>(data);
            _player = new ReactiveProperty<Player>(obj.Player);
            _user = new ReactiveProperty<User>(obj.User);
            _playerDonateValue = new ReactiveProperty<int>(_player.Value.Money.DonateValue);
            _playerPassedLevel = new ReactiveProperty<int>(_player.Value.GameProgress.CurrentGameLevel);
        }

        public void InitPlayerData()
        {
            var newUserGuid = Guid.NewGuid();
            var obj = new PlayerData
            {
                Player = new Player
                {
                    CurrentPlayerLevel = 0,
                    GameProgress = new GameProgress
                    {
                        CurrentGameLevel = 0
                    },
                    Inventory = new Inventory
                    {
                        PlayerItems = new List<InventoryItem>(),
                        SelectedItems = new List<InventoryItem>()
                    },
                    Money = new Money
                    {
                        DonateValue = 0,
                        Energy = 0,
                        InGameValue = 0
                    },
                    UserId = newUserGuid
                },
                User = new User
                {
                    Nickname = "SOBAKA_SUTULAYA",
                    UserId = newUserGuid
                }
            };
            
            _player = new ReactiveProperty<Player>(obj.Player);
            _user = new ReactiveProperty<User>(obj.User);
        }
    }
}