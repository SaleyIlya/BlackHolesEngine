using System;
using System.Collections.Generic;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "BlackHolesEngine/CommonObjects/Items/Item", order = 0)]
    public class ItemScriptableObject : ScriptableObject
    {
        [SerializeField] private string itemId;
        [Header("Coast")]
        [SerializeField] private int inGameValueCoast;
        [SerializeField] private int donateValueCoast;
        [SerializeField] private int energyValueCoast;
        [Header("Description")]
        [SerializeField] private string itemName;
        [SerializeField] private string description;
        [Header("Properties")]
        [SerializeField] private ItemType itemType;
        [SerializeField] private float startPropertyValue;
        [SerializeField] private float propertyGrowValue;
        [SerializeField] private int itemMaxLevel;
        [SerializeField] private List<ItemEffect> effects;
        [SerializeField] private Sprite itemIcon;

        public ShopItem GetShopItem()
        {
            return new ShopItem
            {
                ItemId = Guid.Parse(itemId),
                Cost = new Money
                {
                    InGameValue = inGameValueCoast,
                    DonateValue = donateValueCoast,
                    Energy = energyValueCoast
                }
            };
        }

        public Item GetItem()
        {
            return new Item
            {
                ItemId = Guid.Parse(itemId),
                Name = itemName,
                Description = description,
                Effects = effects,
                ItemType = itemType,
                ItemMaxLevel = itemMaxLevel,
                StartPropertyValue = startPropertyValue,
                PropertyGrowValue = propertyGrowValue,
                ItemIcon = itemIcon
            };
        }
    }
}