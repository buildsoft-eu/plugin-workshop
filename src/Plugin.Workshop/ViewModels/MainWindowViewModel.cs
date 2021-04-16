using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Visualisation;
using Plugin.Workshop.Serialization;

namespace Plugin.Workshop.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public delegate void ImportAction(
            List<IConversionOption> options,
            CancellationToken token,
            out Structure structure,
            out string sourcePath);

        public delegate void ExportAction(
            Structure ubsm,
            string sourcePath,
            List<IConversionOption> options,
            CancellationToken token);

        #region Localizable strings

        public string CancelText => Localization.MainWindow.Cancel;
        public string ExportText => Localization.MainWindow.Export;
        public string ImportText => Localization.MainWindow.Import;
        public string SettingsText => Localization.MainWindow.Settings;
        public string StartText => Localization.MainWindow.Start;

        #endregion

        #region Progress

        public double Progress { get; private set; } = 100.0;
        public string ProgressText { get; private set; } = Localization.MainWindow.Ready;

        public void UpdateProgress(string text, double percentage)
        {
            Progress = percentage;
            ProgressText = text;
            OnPropertyChanged(nameof(Progress));
            OnPropertyChanged(nameof(ProgressText));
        }

        #endregion

        #region Plugin Info

        public Color PluginColor { get; private set; } = new Color { R = 255, G = 196, B = 13 };
        public string PluginExportDescription { get; private set; } = "export description";
        public string PluginIconPath { get; private set; }
        public string PluginImportDescription { get; private set; } = "import description";
        public string PluginName { get; private set; } = "test name";

        public void SetPluginDisplayInfo(
            string iconPath,
            Color color)
        {
            PluginIconPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
                "Images",
                iconPath);
            PluginColor = color;
            OnPropertyChanged(nameof(PluginIconPath));
            OnPropertyChanged(nameof(PluginColor));
        }

        public void SetPluginText(
            string name,
            string importDescription,
            string exportDescription)
        {
            PluginName = name;
            PluginImportDescription = importDescription;
            PluginExportDescription = exportDescription;
            OnPropertyChanged(nameof(PluginName));
            OnPropertyChanged(nameof(PluginImportDescription));
            OnPropertyChanged(nameof(PluginExportDescription));
        }

        public void SetPluginCommands(
            ImportAction import,
            ExportAction export)
        {
            ExportCommand = new AsyncCommand(token => ExportAsync(export, token));
            ImportCommand = new AsyncCommand(token => ImportAsync(import, token));
            OnPropertyChanged(nameof(ExportCommand));
            OnPropertyChanged(nameof(ImportCommand));
        }

        #endregion

        #region Plugin Import

        private string _importPath = "%OneDrive%/PluginWorkshop/01-model-from-import.ubsm";

        public string ImportPath
        {
            get => _importPath;
            set
            {
                _importPath = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand ImportCommand { get; private set; }

        private Task ImportAsync(ImportAction action, CancellationToken token)
        {
            return Task.Run(
                () =>
                {
                    var path = FullPath(_importPath);
                    var directory = Path.GetDirectoryName(path);

                    if (directory == null)
                    {
                        throw new Exception("Export path does not contain a valid directory name");
                    }

                    action(
                        null,
                        token,
                        out var ubsm,
                        out _);

                    var xml = ubsm.ToXml("Model");
                    var doc = new XDocument(xml);
                    doc.Save(
                        path,
                        SaveOptions.None);

                    token.ThrowIfCancellationRequested();
                },
                token);
        }

        #endregion

        #region Plugin Export

        private string _exportPath = "%OneDrive%/PluginWorkshop/01-model-for-export.ubsm";

        public string ExportPath
        {
            get => _exportPath;
            set
            {
                _exportPath = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand ExportCommand { get; private set; }

        private Task ExportAsync(ExportAction action, CancellationToken token)
        {
            return Task.Run(
                () =>
                {
                    var path = FullPath(_exportPath);
                    var doc = XDocument.Load(path);
                    var ubsm = doc.Root.ToStructure();

                    action(
                        ubsm,
                        null,
                        null,
                        token);

                    token.ThrowIfCancellationRequested();
                },
                token);
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Helpers

        private static string FullPath(string path)
        {
            return Path.GetFullPath(Environment.ExpandEnvironmentVariables(path));
        }

        #endregion
    }
}
