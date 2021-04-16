using System.IO;
using BuildSoft.BIMExpert.Plugin;
using Newtonsoft.Json;
using Plugin.Example.Models;

namespace Plugin.Example.Services
{
    public class SettingsRepository : ISettingsRepository
    {
        // settings will be saved in the current version application data directory
        // %LocalAppData%/BuildSoft/BIMExpert/0.0
        private readonly string _path = Path.Combine(
            BIMExpert.WorkingDirectory,
            "example.json");

        public Settings Get()
        {
            if (!File.Exists(_path))
            {
                return new Settings();
            }

            using var reader = File.OpenText(_path);
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public void Set(Settings newSettings)
        {
            var json = JsonConvert.SerializeObject(newSettings);
            File.WriteAllText(_path, json);
        }
    }
}
