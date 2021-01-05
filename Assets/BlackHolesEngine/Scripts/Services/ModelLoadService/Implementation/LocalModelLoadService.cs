using System;
using System.IO;
using System.Text;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService.Implementation
{
    public class LocalModelLoadService : IModelLoadService
    {
        public void SaveData(IModel model, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var file = File.Create(path);
            var stringData = model.GetDataToSave();
            var bytesArray = Encoding.UTF8.GetBytes(stringData);
            file.Write(bytesArray, 0, bytesArray.Length);
        }

        public void LoadData(IModel model, string path)
        {
            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                model.InitData(data);
                return;
            }
            
            model.InitData();
        }
    }
}