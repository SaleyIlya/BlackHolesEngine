using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ReactiveProperty<bool> _sound;
        private ReactiveProperty<bool> _vibration;
        private Guid _userId;
        private ReadOnlyDictionary<Guid, Item> _gameItems;
        private ReadOnlyDictionary<Guid, ShopItem> _shopItems;
        
        public ReactiveProperty<int> PlayerPassedLevel => _playerPassedLevel;
        public ReactiveProperty<int> PlayerDonateValue => _playerDonateValue;
        public ReactiveProperty<float> CurrentPlayerLevel => _currentPlayerLevel;
        public ReactiveCollection<InventoryItem> PlayerItems => _playerItems;
        public ReactiveCollection<InventoryItem> SelectedPlayerItems => _selectedPlayerItems;
        public ReactiveProperty<int> PlayerEnergy => _playerEnergy;
        public ReactiveProperty<int> PlayerInGameValue => _playerInGameValue;
        public ReactiveProperty<string> PlayerNickname => _playerNickname;
        public ReactiveProperty<bool> Sound => _sound;
        public ReactiveProperty<bool> Vibration => _vibration;

        public Guid UserId => _userId;
        public ReadOnlyDictionary<Guid, Item> GameItems => _gameItems;
        public ReadOnlyDictionary<Guid, ShopItem> ShopItems => _shopItems;

        private GameApplicationConfig _applicationConfig;
        private IModelLoadService _modelLoadService;

        public void Init(GameApplicationConfig gameApplicationConfigScriptableObject)
        {
            _applicationConfig = gameApplicationConfigScriptableObject;
            _gameItems = gameApplicationConfigScriptableObject.GetGameItems();
            _shopItems = gameApplicationConfigScriptableObject.GetShopItems();
            ServiceLocator.Default.Resolve<IModelLoadService>().LoadPlayerData(this, 
                _applicationConfig.PlayerDataPath,
                _applicationConfig.PlayerSettingsPath);
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

        public string GetPlayerSettings()
        {
            var obj = new Settings
            {
                Sound = _sound.Value,
                Vibration = _vibration.Value
            };
            return JsonConvert.SerializeObject(obj);
        }

        public void InitPlayerData(string playerData, string playerSettings)
        {
            var data = JsonConvert.DeserializeObject<PlayerData>(playerData);
            var settings = JsonConvert.DeserializeObject<Settings>(playerSettings);

            FillModel(data, settings);
        }

        private void FillModel(PlayerData data, Settings settings)
        {
            _playerDonateValue = new ReactiveProperty<int>(data.Player.Money.DonateValue);
            _playerPassedLevel = new ReactiveProperty<int>(data.Player.GameProgress.CurrentGameLevel);
            _currentPlayerLevel = new ReactiveProperty<float>(data.Player.CurrentPlayerLevel);
            _playerItems = new ReactiveCollection<InventoryItem>(data.Player.Inventory.PlayerItems);
            _selectedPlayerItems = new ReactiveCollection<InventoryItem>(data.Player.Inventory.SelectedItems);
            _playerEnergy = new ReactiveProperty<int>(data.Player.Money.Energy);
            _playerInGameValue = new ReactiveProperty<int>(data.Player.Money.InGameValue);
            _playerNickname = new ReactiveProperty<string>(data.User.Nickname);
            _userId = data.User.UserId;

            _sound = new ReactiveProperty<bool>(settings.Sound);
            _vibration = new ReactiveProperty<bool>(settings.Vibration);
        }

        public void InitPlayerData()
        {
            var newUserGuid = Guid.NewGuid();
            var data = new PlayerData
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
            var settings = new Settings
            {
                Sound = true,
                Vibration = true
            };
            
            FillModel(data, settings);
        }
    }
}