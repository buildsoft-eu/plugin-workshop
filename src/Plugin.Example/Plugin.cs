using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Visualisation;
using Plugin.Example.Services;
using Plugin.Example.ViewModels;
using Plugin.Example.Views;
using SettingsViewModel = BuildSoft.BIMExpert.Plugin.SettingsViewModel;

namespace Plugin.Example
{
    public class Plugin : IUBSMConverter
    {
        #region Bootstrap

        private readonly ISettingsRepository _settingsRepository = new SettingsRepository();

        public Plugin()
        {
            _settingsViewModel = new ViewModels.SettingsViewModel(_settingsRepository);
        }

        #endregion

        #region Info

        public Guid ID => Guid.Parse("d63d73df-6703-4370-ae57-74fae91b2386");  // todo: pick a unique identifier

        public string Name => Localization.General.Name;  // todo: update localization resources

        public ExchangeDirection AllowedExchange => ExchangeDirection.ImportAndExport;  // todo: set supported directions

        public Color Color => new Color { R = 238, G = 187, B = 68 };  // todo: pick a color

        public string IconName => "logo.png";  // todo: point to your own icon in the Images folder that is set to output to bin

        public CultureInfo UICulture { get; set; }

        #endregion

        #region Export

        private readonly ExportViewModel _exportViewModel = new ExportViewModel();

        public string ExportDescription => Localization.Export.Description;

        public UserControl CreateExportControl()
        {
            return new Export
            {
                DataContext = _exportViewModel
            };
        }

        public void ConvertBack(
            Structure ubsm,
            string sourcePath,
            List<IConversionOption> options,
            CancellationToken token)
        {
            ConvertBackAsync(ubsm, sourcePath, options, token)
                .Wait(token);
        }

        private async Task ConvertBackAsync(
            Structure ubsm,
            string sourcePath,
            List<IConversionOption> options,
            CancellationToken token)
        {
            OnProgressChanged("Starting...", 0.0);

            for (var i = 0; i < 20; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(100, CancellationToken.None);
                var percentage = (i + 1) * 5d;
                OnProgressChanged($"Export: making progress... ({percentage}%)", percentage);
            }

            OnProgressChanged("All done", 100);

            throw new Exception("test exception behaviour");
        }

        #endregion

        #region Import

        private readonly ImportViewModel _importViewModel = new ImportViewModel();

        public string ImportDescription => Localization.Import.Description;

        public UserControl CreateImportControl()
        {
            return new Import()
            {
                DataContext = _importViewModel
            };
        }

        public void Convert(
            List<IConversionOption> options,
            CancellationToken token,
            out Structure ubsm,
            out string sourcePath)
        {
            var (structure, path) = ConvertAsync(options, token)
                .Result;

            ubsm = structure;
            sourcePath = path;
        }

        private async Task<(Structure, string)> ConvertAsync(
            List<IConversionOption> options,
            CancellationToken token)
        {
            OnProgressChanged("Starting...", 0.0);

            for (var i = 0; i < 20; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(100, CancellationToken.None);
                var percentage = (i + 1) * 5d;
                OnProgressChanged($"Import: making progress... ({percentage}%)", percentage);
            }

            OnProgressChanged("All done", 100);

            return (new Structure(), null);
        }

        #endregion

        #region Progress

        public double Progress { get; private set; }

        public string ProgressInformation { get; private set; }

        public event EventHandler ProgressChanged;

        private void OnProgressChanged(
            string information,
            double percentage)
        {
            Progress = percentage;
            ProgressInformation = information;
            ProgressChanged?.Invoke(this, null);
        }

        #endregion

        #region Settings

        private readonly SettingsViewModel _settingsViewModel;

        public UserControl CreateSettingsControl()
        {
            return new Settings
            {
                DataContext = _settingsViewModel
            };
        }

        #endregion
    }
}
