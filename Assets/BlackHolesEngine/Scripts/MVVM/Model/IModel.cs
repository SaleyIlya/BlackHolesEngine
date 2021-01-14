using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using UniRx;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model
{
    public interface IModel
    {
        void Init(GameApplicationConfig gameApplicationConfigScriptableObject);
        string GetPlayerData();
        string GetPlayerSettings();
        void InitPlayerData(string playerData, string playerSettings);
        void InitPlayerData();
        LevelSettings GetLevelSettings(int level);
        
        ReactiveProperty<int> PlayerPassedLevel { get; }
        ReactiveProperty<int> PlayerDonateValue { get; }
        ReactiveProperty<float> CurrentPlayerLevel { get; }
        ReactiveCollection<InventoryItem> PlayerItems { get; }
        ReactiveCollection<InventoryItem> SelectedPlayerItems { get; }
        ReactiveProperty<int> PlayerEnergy { get; }
        ReactiveProperty<int> PlayerInGameValue { get; }
        ReactiveProperty<string> PlayerNickname { get; }
        ReactiveProperty<bool> Sound { get; }
        ReactiveProperty<bool> Vibration { get; }
        
        Guid UserId { get; }
        GameData GameData { get; }
        
        ReadOnlyDictionary<Guid, Item> GameItems { get; }
        ReadOnlyDictionary<Guid, ShopItem> ShopItems { get; }
    }
}