using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService
{
    public interface IModelLoadService
    {
        void SavePlayerData(IModel model, string path);
        void LoadPlayerData(IModel model, string path);
    }
}