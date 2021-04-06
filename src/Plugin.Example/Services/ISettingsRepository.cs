using Plugin.Example.Models;

namespace Plugin.Example.Services
{
    public interface ISettingsRepository
    {
        Settings Get();
        void Set(Settings newSettings);
    }
}
