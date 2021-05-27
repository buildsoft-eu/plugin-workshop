using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BuildSoft.Linq;
using Example.API;
using Newtonsoft.Json;
using Plugin.Example.Localization;
using Plugin.Example.Services;

namespace Plugin.Example.ViewModels
{
    public class LoadFromApiViewModel : ViewModelWithContinueBase, IApiLoader, INotifyDataErrorInfo
    {
        public string SelectFileText => LoadFromApi.SelectFile;

        private string _path = "%OneDrive%/PluginWorkshop/api-model-for-import.json";

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged();
                CheckIfCanContinue();
                GetErrorsForPath(value)
                    .ContinueWith(
                        errorsTask =>
                        {
                            lock (_validationLock)
                            {
                                _validationErrors[nameof(Path)] = errorsTask.Result;
                                OnErrorsChanged();
                            }
                        });
            }
        }

        public Func<Task> WaitForCompletion { private get; set; }

        private static string GetFullPath(string path)
        {
            return System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(path));
        }

        private void CheckIfCanContinue()
        {
            var canContinue = IsValidPath(_path);
            SetContinuation(canContinue);
        }

        private static bool IsValidPath(string path)
        {
            var fullPath = GetFullPath(path);
            return File.Exists(fullPath);
        }

        public async Task<Model> LoadAsync(CancellationToken token)
        {
            CheckIfCanContinue();
            SetVisibility(true);
            await WaitForCompletion()
                .TryCatchCancellationAsync(
                    token,
                    () => SetVisibility(false));
            SetVisibility(false);
            var json = File.ReadAllText(GetFullPath(_path));
            return JsonConvert.DeserializeObject<Model>(json);
        }

        private object _validationLock = new();
        private Dictionary<string, List<string>> _validationErrors = new();

        public IEnumerable GetErrors(string propertyName)
        {
            lock (_validationLock)
            {
                if (_validationErrors.TryGetValue(propertyName, out var result))
                {
                    return result;
                }
            }

            return null;
        }

        public bool HasErrors => HasDictionaryAnyErrors();

        private bool HasDictionaryAnyErrors()
        {
            lock (_validationLock)
            {
                return _validationErrors.Any(kvp => kvp.Value.HasElements());
            }
        }

        private Task<List<string>> GetErrorsForPath(string value)
        {
            return Task.Run(
                () => IsValidPath(value)
                    ? null
                    : new List<string> { "Path is not valid" });
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
