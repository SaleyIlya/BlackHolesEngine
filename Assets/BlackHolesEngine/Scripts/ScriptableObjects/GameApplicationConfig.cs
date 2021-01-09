using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameApplicationConfig", menuName = "BlackHolesEngine/GameApplicationConfig", order = 0)]
    public class GameApplicationConfig : ScriptableObject 
    {
        [SerializeField] private string playerDataPath;
        [SerializeField] private string playerSettingsPath;
        [SerializeField] private List<Item> gameItems;
        [SerializeField] private List<ShopItem> shopItems;
        [SerializeField] private List<string> guids;
        

        public string PlayerDataPath => Path.Combine(Application.persistentDataPath, playerDataPath);
        public string PlayerSettingsPath => Path.Combine(Application.persistentDataPath, playerSettingsPath);

        public ReadOnlyDictionary<Guid, Item> GetGameItems()
        {
            for (int i = 0; i < gameItems.Count; i++)
            {
                gameItems[i].ItemId = Guid.Parse(guids[i]);
            }
            var gameItemsDictionary = gameItems.ToDictionary(x => x.ItemId, y => y);
            return new ReadOnlyDictionary<Guid, Item>(gameItemsDictionary);
        }
        
        public ReadOnlyDictionary<Guid, ShopItem> GetShopItems()
        {
            for (int i = 0; i < shopItems.Count; i++)
            {
                shopItems[i].ItemId = Guid.Parse(guids[i]);
            }
            var shopDictionary = shopItems.ToDictionary(x => x.ItemId, y => y);
            return new ReadOnlyDictionary<Guid, ShopItem>(shopDictionary);
        }
    }
}