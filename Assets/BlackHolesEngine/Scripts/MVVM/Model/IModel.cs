using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using UniRx;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model
{
    public interface IModel
    {
        void Init(GameApplicationConfig gameApplicationConfigScriptableObject);
        string GetPlayerData();
        void InitPlayerData(string data);
        void InitPlayerData();
        
        ReactiveProperty<int> PlayerPassedLevel { get; }
        ReactiveProperty<int> PlayerDonateValue { get; }
        ReactiveProperty<Player> Player { get; }
        ReactiveProperty<User> User { get; }
    }
}