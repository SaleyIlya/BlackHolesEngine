using System.Collections.Generic;
using System.Linq;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.ScriptableLibrary
{
    public static class ListExtensions
    {
        public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(this IEnumerable<SKeyValuePair<TKey, TValue>> collection)
            => collection.ToDictionary(
                x => x.Key,
                y => y.Value);
    }
}