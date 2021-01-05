using System;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    [System.Serializable]
    public class User
    {
        [JsonProperty("userId"), ShowInInspector] 
        public Guid UserId;
        [JsonProperty("nickname"), ShowInInspector] 
        public string Nickname;
    }
}