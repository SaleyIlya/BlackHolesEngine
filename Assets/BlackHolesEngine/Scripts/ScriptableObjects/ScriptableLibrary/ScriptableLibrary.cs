using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.ScriptableLibrary
{
    public abstract class ScriptableLibrary<TPair, TKey, TValue> : ScriptableObject 
        where TPair : SKeyValuePair<TKey, TValue>
    {
        [SerializeField] private List<TPair> library;

        private Dictionary<TKey, TValue> _libraryDictionary;
        public Dictionary<TKey, TValue> Library 
            => _libraryDictionary ?? (_libraryDictionary = library.GetDictionary());
    }
}