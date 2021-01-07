using System;
using System.IO;
using System.Text;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService.Implementation
{
    public class LocalModelLoadService : IModelLoadService
    {
        public void SavePlayerData(IModel model, string playerDataPath, string playerSettingsPath)
        {
            SaveDataInPath(model.GetPlayerData(), playerDataPath);
            SaveDataInPath(model.GetPlayerSettings(), playerSettingsPath);
        }
        
        private void SaveDataInPath(string data, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var file = File.Create(path);
            var stringData = data;
            var bytesArray = Encoding.UTF8.GetBytes(stringData);
            file.Write(bytesArray, 0, bytesArray.Length);
        }

        public void LoadPlayerData(IModel model, string playerDataPath, string playerSettingsPath)
        {
            string playerData = null;
            string playerSettings = null;
            
            if (File.Exists(playerDataPath))
            {
                playerData = File.ReadAllText(playerDataPath);
            }
            if (File.Exists(playerSettingsPath))
            {
                playerSettings = File.ReadAllText(playerSettingsPath);
            }

            if (!string.IsNullOrEmpty(playerData) && !string.IsNullOrEmpty(playerSettings))
            {
                model.InitPlayerData(playerData, playerSettings);
                return;
            }
            
            model.InitPlayerData();
        }
    }
}