using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model
{
    public interface IModel
    {
        bool Init(GameApplicationConfig gameApplicationConfigScriptableObject);
    }
}