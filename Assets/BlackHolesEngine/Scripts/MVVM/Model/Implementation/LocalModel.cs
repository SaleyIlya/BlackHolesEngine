using System;
using System.Collections.Generic;
using System.Linq;
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
        private ReactiveProperty<int> _playerPassedLevel;
        private ReactiveProperty<int> _playerDonateValue;
        private ReactiveProperty<float> _currentPlayerLevel;
        private ReactiveCollection<InventoryItem> _playerItems;
        private ReactiveCollection<InventoryItem> _selectedPlayerItems;
        private ReactiveProperty<int> _playerEnergy;
        private ReactiveProperty<int> _playerInGameValue;
        private ReactiveProperty<string> _playerNickname;
        private Guid _userId;
        
        public ReactiveProperty<int> PlayerPassedLevel => _playerPassedLevel;
        public ReactiveProperty<int> PlayerDonateValue => _playerDonateValue;
        public ReactiveProperty<float> CurrentPlayerLevel => _currentPlayerLevel;
        public ReactiveCollection<InventoryItem> PlayerItems => _playerItems;
        public ReactiveCollection<InventoryItem> SelectedPlayerItems => _selectedPlayerItems;
        public ReactiveProperty<int> PlayerEnergy => _playerEnergy;
        public ReactiveProperty<int> PlayerInGameValue => _playerInGameValue;
        public ReactiveProperty<string> PlayerNickname => _playerNickname;
        public Guid UserId => _userId;

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
                Player = new Player
                {
                    CurrentPlayerLevel = _currentPlayerLevel.Value,
                    GameProgress = new GameProgress
                    {
                        CurrentGameLevel = _playerPassedLevel.Value
                    },
                    Inventory = new Inventory
                    {
                        PlayerItems = _playerItems.ToList(),
                        SelectedItems = _selectedPlayerItems.ToList()
                    },
                    Money = new Money
                    {
                        DonateValue = _playerDonateValue.Value,
                        Energy = _playerEnergy.Value,
                        InGameValue = _playerInGameValue.Value
                    },
                    UserId = _userId
                },
                User = new User
                {
                    Nickname = _playerNickname.Value,
                    UserId = _userId
                }
            };
            return JsonConvert.SerializeObject(obj);
        }

        public void InitPlayerData(string data)
        {
            var obj = JsonConvert.DeserializeObject<PlayerData>(data);

            FillModel(obj);
        }

        private void FillModel(PlayerData obj)
        {
            _playerDonateValue = new ReactiveProperty<int>(obj.Player.Money.DonateValue);
            _playerPassedLevel = new ReactiveProperty<int>(obj.Player.GameProgress.CurrentGameLevel);
            _currentPlayerLevel = new ReactiveProperty<float>(obj.Player.CurrentPlayerLevel);
            _playerItems = new ReactiveCollection<InventoryItem>(obj.Player.Inventory.PlayerItems);
            _selectedPlayerItems = new ReactiveCollection<InventoryItem>(obj.Player.Inventory.SelectedItems);
            _playerEnergy = new ReactiveProperty<int>(obj.Player.Money.Energy);
            _playerInGameValue = new ReactiveProperty<int>(obj.Player.Money.InGameValue);
            _playerNickname = new ReactiveProperty<string>(obj.User.Nickname);
            _userId = obj.User.UserId;
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
            
            FillModel(obj);
        }
    }
}