using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Items;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Levels;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameApplicationConfig", menuName = "BlackHolesEngine/GameApplicationConfig", order = 0)]
    public class GameApplicationConfig : ScriptableObject 
    {
        [SerializeField] private string playerDataPath;
        [SerializeField] private string playerSettingsPath;
        [Header("ScriptableObjects")]
        [SerializeField] private GameDataScriptableObject gameData;
        [SerializeField] private ItemLibraryScriptableObject itemsLibrary;
        [SerializeField] private LevelsLibraryScriptableObject levelsLibrary;

        public string PlayerDataPath => Path.Combine(Application.persistentDataPath, playerDataPath);
        public string PlayerSettingsPath => Path.Combine(Application.persistentDataPath, playerSettingsPath);

        public ReadOnlyDictionary<Guid, Item> GetGameItems()
        {
            var dictionary = itemsLibrary.Library.ToDictionary(x => Guid.Parse(x.Key), y => y.Value.GetItem());
            return new ReadOnlyDictionary<Guid, Item>(dictionary);
        }
        
        public ReadOnlyDictionary<Guid, ShopItem> GetShopItems()
        {
            return new ReadOnlyDictionary<Guid, ShopItem>(
                itemsLibrary.Library.ToDictionary(x => Guid.Parse(x.Key), y => y.Value.GetShopItem()));
        }

        public GameData GetGameData()
        {
            return gameData.GetGameData();
        }

        public ReadOnlyDictionary<int, LevelSettings> GetLevelsSettings()
        {
            return new ReadOnlyDictionary<int, LevelSettings>(
                levelsLibrary.Library.ToDictionary(x => x.Key, y => y.Value.GetLevelSettings()));
        }
    }
}