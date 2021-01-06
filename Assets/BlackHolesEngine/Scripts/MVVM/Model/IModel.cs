using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model
{
    public interface IModel //todo add reactive properties
    {
        void Init(GameApplicationConfig gameApplicationConfigScriptableObject);
        string GetPlayerData();
        void InitPlayerData(string data);
        void InitPlayerData();
    }
}