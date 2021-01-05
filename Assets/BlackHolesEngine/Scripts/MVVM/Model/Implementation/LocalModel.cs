using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects;
using BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Model.Implementation
{
    public class LocalModel : IModel
    {
        private GameApplicationConfig _applicationConfig;
        private IModelLoadService _modelLoadService;
        
        public void Init(GameApplicationConfig gameApplicationConfigScriptableObject)
        {
            _applicationConfig = gameApplicationConfigScriptableObject;
            ServiceLocator.Default.Resolve<IModelLoadService>().LoadData(this, _applicationConfig.SaveLoadPath);
        }

        public string GetDataToSave()
        {
            throw new System.NotImplementedException();
        }

        public void InitData(string data)
        {
            throw new System.NotImplementedException();
        }

        public void InitData()
        {
            throw new System.NotImplementedException();
        }
    }
}