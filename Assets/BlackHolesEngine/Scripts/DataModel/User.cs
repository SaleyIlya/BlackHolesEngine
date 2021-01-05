using Newtonsoft.Json;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    public class User
    {
        [JsonProperty("login")]
        public string Login { get; set; }
    }
}