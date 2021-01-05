using System;
using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class User
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
    }
}