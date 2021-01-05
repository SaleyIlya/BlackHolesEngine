using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService
{
    public interface IModelLoadService
    {
        void SaveData(IModel model, string path);
        void LoadData(IModel model, string path);
    }
}