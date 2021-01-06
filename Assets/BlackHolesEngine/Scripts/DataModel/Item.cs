using System;
using System.Collections.Generic;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.DataModel
{
    /// <summary>
    /// Описание параметров предмета
    /// </summary>
    [System.Serializable]
    public class Item
    {
        /// <summary>
        /// Айдишник для сопоставления со предметом в инвентаре и предметом в магазине
        /// </summary>
        [JsonProperty("itemId"), ShowInInspector]
        public Guid ItemId { get; set; }
        /// <summary>
        /// Тип предмета
        /// </summary>
        [JsonProperty("itemType"), ShowInInspector]
        public ItemType ItemType { get; set; }
        /// <summary>
        /// Начальное значения показателя предмета
        /// </summary>
        [JsonProperty("startPropertyValue"), ShowInInspector]
        public float StartPropertyValue { get; set; }
        /// <summary>
        /// Максимальный уровень предмета
        /// </summary>
        [JsonProperty("itemMaxLevel"), ShowInInspector]
        public int ItemMaxLevel { get; set; }
        /// <summary>
        /// Значение, на которое растет показатель предмета при росте уровня
        /// </summary>
        [JsonProperty("propertyGrowValue"), ShowInInspector]
        public float PropertyGrowValue { get; set; }
        /// <summary>
        /// Перечисление эффектов предмета
        /// </summary>
        [JsonProperty("effects"), ShowInInspector]
        public List<ItemEffect> Effects { get; set; }
        /// <summary>
        /// Название предмета
        /// </summary>
        [JsonProperty("name"), ShowInInspector]
        public string Name { get; set; }
        /// <summary>
        /// Описание предмета
        /// </summary>
        [JsonProperty("description"), ShowInInspector]
        public string Description { get; set; }
        /// <summary>
        /// Иконка предмета для юи
        /// </summary>
        [JsonIgnore, ShowInInspector]
        public Sprite ItemIcon { get; set; }
    }
}