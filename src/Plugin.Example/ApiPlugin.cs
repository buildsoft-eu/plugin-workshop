using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM;
using Plugin.Example.Services;
using Plugin.Example.ViewModels;
using Plugin.Example.Views;
using Color = BuildSoft.UBSM.Visualisation.Color;
using Dispatcher = System.Windows.Threading.Dispatcher;
using Settings = Plugin.Example.Views.Settings;
using SettingsViewModel = Plugin.Example.ViewModels.SettingsViewModel;

namespace Plugin.Example
{
    public class ApiPlugin : IUBSMConverter
    {
        #region Bootstrap

        private readonly ISettingsRepository _settingsRepository = new SettingsRepository();
        private readonly IUbsmDatabase _ubsmDatabase = new UbsmDatabase();

        public ApiPlugin()
        {
            _settingsViewModel = new SettingsViewModel(_settingsRepository);
        }

        #endregion

        #region Info

        public Guid ID => Guid.Parse("d63d73df-6703-4370-ae57-74fae91b2386");  // todo: pick a unique identifier

        public string Name => Localization.General.Name;  // todo: update localization resources

        public ExchangeDirection AllowedExchange => ExchangeDirection.ImportAndExport;  // todo: set supported directions

        public Color Color => new() { R = 238, G = 187, B = 68 };  // todo: pick a color

        public string IconName => "logo.png";  // todo: point to your own icon in the Images folder that is set to output to bin

        public CultureInfo UICulture { get; set; }

        #endregion

        #region Export

        private readonly ExportViewModel _exportViewModel = new();

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
                .GetAwaiter()
                .GetResult();
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
                token.ThrowIfCancellationRequested();
                _exportViewModel.UpdateTitle($"Running in loop {i}");

                await Task.Delay(100, CancellationToken.None);
                var percentage = (i + 1) * 5d;
                OnProgressChanged("Export: making progress...", percentage);
            }

            OnProgressChanged("All done", 100);

            throw new Exception("test exception behaviour");
        }

        #endregion

        #region Import

        private readonly ImportViewModel _importViewModel = new();
        private LoadFromApiViewModel _loadFromApiViewModel;
        private MaterialConflictsViewModel _materialConflictsViewModel;
        private SectionConflictsViewModel _sectionConflictsViewModel;
        private Dispatcher _importDispatcher;

        public string ImportDescription => Localization.Import.Description;

        public UserControl CreateImportControl()
        {
            var control = new Import
            {
                DataContext = _importViewModel
            };
            _importDispatcher = control.Dispatcher;

            _loadFromApiViewModel = (LoadFromApiViewModel)control.LoadFromApi.DataContext;
            _loadFromApiViewModel.WaitForCompletion =
                async () =>
                {
                    await control.LoadFromApi.ContinueButton;
                };

            _materialConflictsViewModel = (MaterialConflictsViewModel)control.MaterialConflicts.DataContext;
            _materialConflictsViewModel.WaitForConflictResolutionCompletion =
                async () =>
                {
                    await control.MaterialConflicts.ContinueButton;
                };

            _sectionConflictsViewModel = (SectionConflictsViewModel)control.SectionConflicts.DataContext;
            _sectionConflictsViewModel.WaitForConflictResolutionCompletion =
                async () =>
                {
                    await control.SectionConflicts.ContinueButton;
                };

            return control;
        }

        /// <summary>
        /// This is the entry point of the plugin, it's task is to bootstrap all dependencies
        /// and hook up the UI correctly to the actual import service.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="token"></param>
        /// <param name="ubsm"></param>
        /// <param name="sourcePath"></param>
        public void Convert(
            List<IConversionOption> options,
            CancellationToken token,
            out Structure ubsm,
            out string sourcePath)
        {
            // initialize
            _materialConflictsViewModel.Initialize();
            _sectionConflictsViewModel.Initialize();

            // observable collections can only be updated from GUI thread
            EnableSynchronization(_materialConflictsViewModel);
            EnableSynchronization(_sectionConflictsViewModel);

            var importService = new ImportService(
                _loadFromApiViewModel,
                _materialConflictsViewModel,
                _sectionConflictsViewModel,
                _ubsmDatabase,
                new IdGenerator(),
                _settingsViewModel.Data);
            var progress = new Progress<(string, double)>(
                t => OnProgressChanged(t.Item1, t.Item2));

            // import from API and create UBSM
            var (structure, path) = importService.RunAsync(
                    _importViewModel.UpdateTitle,
                    progress,
                    token)
                .GetAwaiter()
                .GetResult();

            // finalize
            DisableSynchronization(_materialConflictsViewModel);
            DisableSynchronization(_sectionConflictsViewModel);

            ubsm = structure;
            sourcePath = path;
        }

        private void EnableSynchronization<TConflictViewModel, TUbsm, TApi>(
            ConflictsViewModelBase<TConflictViewModel, TUbsm, TApi> conflictsViewModel)
        where TConflictViewModel : IConflictViewModel
        {
            _importDispatcher.Invoke(
                () =>
                {
                    var collectionLock = new object();
                    BindingOperations.EnableCollectionSynchronization(conflictsViewModel.Conflicts, collectionLock);
                    BindingOperations.EnableCollectionSynchronization(conflictsViewModel.Mappings, collectionLock);
                });
        }

        private void DisableSynchronization<TConflictViewModel, TUbsm, TApi>(
            ConflictsViewModelBase<TConflictViewModel, TUbsm, TApi> conflictsViewModel)
        where TConflictViewModel : IConflictViewModel
        {
            _importDispatcher.Invoke(
                () =>
                {
                    // observable collections can only be updated from GUI thread
                    BindingOperations.DisableCollectionSynchronization(conflictsViewModel.Conflicts);
                    BindingOperations.DisableCollectionSynchronization(conflictsViewModel.Mappings);
                });
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
            ProgressInformation = information + $" ({percentage}%)";
            Debug.WriteLine($"> PROGRESS: {ProgressInformation}");
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
