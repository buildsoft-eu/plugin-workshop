using System;
using System.IO;
using System.Threading.Tasks;
using Example.API;
using Newtonsoft.Json;
using Plugin.Example.Localization;
using Plugin.Example.Services;

namespace Plugin.Example.ViewModels
{
    public class LoadFromApiViewModel : ViewModelBase, IApiLoader
    {
        public string ContinueText => General.Continue;

        public string SelectFileText => LoadFromApi.SelectFile;

        public bool CanContinue { get; private set; }

        public void SetContinue(bool value)
        {
            CanContinue = value;
            OnPropertyChanged(nameof(CanContinue));
        }

        private string _path = "%OneDrive%/PluginWorkshop/api-model-for-import.json";

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged();
                CheckIfCanContinue();
            }
        }

        public bool IsVisible { get; private set; }

        private void SetVisibility(bool value)
        {
            IsVisible = value;
            OnPropertyChanged(nameof(IsVisible));
        }

        public Func<Task> WaitForCompletion { private get; set; }

        public string GetFullPath()
        {
            return System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(_path));
        }

        private void CheckIfCanContinue()
        {
            var path = GetFullPath();
            var canContinue = File.Exists(path);
            SetContinue(canContinue);
        }

        public async Task<Model> LoadAsync()
        {
            CheckIfCanContinue();
            SetVisibility(true);
            await WaitForCompletion();
            SetVisibility(false);
            var json = File.ReadAllText(GetFullPath());
            return JsonConvert.DeserializeObject<Model>(json);
        }
    }
}
