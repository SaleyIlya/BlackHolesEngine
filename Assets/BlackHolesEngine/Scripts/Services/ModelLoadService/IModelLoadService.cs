using BlackHoles.BlackHolesEngine.Scripts.MVVM.Model;

namespace BlackHoles.BlackHolesEngine.Scripts.Services.ModelLoadService
{
    public interface IModelLoadService
    {
        void SavePlayerData(IModel model, string playerDataPath, string playerSettingsPath);
        void LoadPlayerData(IModel model, string playerDataPath, string playerSettingsPath);
    }
}