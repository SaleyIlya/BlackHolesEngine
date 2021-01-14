namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.ScriptableLibrary
{
    public class SKeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public void SetKey(TKey newKey)
        {
            Key = newKey;
        }
    }
}