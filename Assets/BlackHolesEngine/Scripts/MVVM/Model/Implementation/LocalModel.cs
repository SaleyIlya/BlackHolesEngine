using System;
using System.Collections.Generic;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation
{
    public class LocalModel : IModel
    {
        private GameApplicationConfig _applicationConfig;
        private IModelLoadService _modelLoadService;
        
        public void Init(GameApplicationConfig gameApplicationConfigScriptableObject)
        {
            _applicationConfig = gameApplicationConfigScriptableObject;
            ServiceLocator.Default.Resolve<IModelLoadService>().LoadPlayerData(this, _applicationConfig.SaveLoadPath);
        }

        public string GetPlayerData()
        {
            var obj = _applicationConfig.PlayerData; //todo rework
            return JsonConvert.SerializeObject(obj);
        }

        public void InitPlayerData(string data)
        {
            var obj = JsonConvert.DeserializeObject<PlayerData>(data);
            _applicationConfig.PlayerData = obj; //todo rework
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
            _applicationConfig.PlayerData = obj; //todo rework
        }
    }
}