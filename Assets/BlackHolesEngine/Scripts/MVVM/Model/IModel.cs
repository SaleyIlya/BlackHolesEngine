using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model
{
    public interface IModel
    {
        void Init(GameApplicationConfig gameApplicationConfigScriptableObject);
        string GetDataToSave();
        void InitData(string data);
        void InitData();
    }
}