using Newtonsoft.Json;
using Sirenix.OdinInspector;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание денежных единиц
    /// </summary>
    [System.Serializable]
    public class Money
    {
        /// <summary>
        /// Кол-во внутриигровой валюты
        /// </summary>
        [JsonProperty("inGameValue"), ShowInInspector]
        public int InGameValue { get; set; }
        /// <summary>
        /// Кол-во донатной валюты
        /// </summary>
        [JsonProperty("donateValue"), ShowInInspector]
        public int DonateValue { get; set; }
        /// <summary>
        /// Кол-во энергии
        /// </summary>
        [JsonProperty("energy"), ShowInInspector]
        public int Energy { get; set; }
    }
}