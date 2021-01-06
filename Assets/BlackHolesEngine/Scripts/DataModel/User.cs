using System;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание учетки игрока
    /// </summary>
    [System.Serializable]
    public class User
    {
        /// <summary>
        /// Айди пользователя
        /// </summary>
        [JsonProperty("userId"), ShowInInspector] 
        public Guid UserId;
        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        [JsonProperty("nickname"), ShowInInspector] 
        public string Nickname;
    }
}