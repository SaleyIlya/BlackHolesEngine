using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class Settings
    {
        [ShowInInspector]
        public bool Sound { get; set; }
        [ShowInInspector]
        public bool Vibration { get; set; }
    }
}