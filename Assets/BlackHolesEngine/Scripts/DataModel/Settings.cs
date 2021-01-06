using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание настроек игрока
    /// </summary>
    [System.Serializable]
    public class Settings
    {
        /// <summary>
        /// Настройки воспроизведения звука
        /// </summary>
        [ShowInInspector]
        public bool Sound { get; set; }
        /// <summary>
        /// Настройки воспроизведения вибрации
        /// </summary>
        [ShowInInspector]
        public bool Vibration { get; set; }
    }
}