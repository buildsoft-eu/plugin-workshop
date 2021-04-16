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
using BuildSoft.UBSM.Physical;
using Plugin.Example.Services;
using Plugin.Example.ViewModels;
using Plugin.Example.Views;
using Color = BuildSoft.UBSM.Visualisation.Color;
using Dispatcher = System.Windows.Threading.Dispatcher;
using Settings = Plugin.Example.Views.Settings;
using SettingsViewModel = BuildSoft.BIMExpert.Plugin.SettingsViewModel;

namespace Plugin.Example
{
    public class ApiPlugin : IUBSMConverter
    {
        #region Bootstrap

        private readonly ISettingsRepository _settingsRepository = new SettingsRepository();
        private readonly IUbsmDatabase _ubsmDatabase = new UbsmDatabase();

        public ApiPlugin()
        {
            _settingsViewModel = new ViewModels.SettingsViewModel(_settingsRepository);
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
        private MaterialConflictsViewModel _materialConflictsViewModel;
        private Dispatcher _importDispatcher;

        public string ImportDescription => Localization.Import.Description;

        public UserControl CreateImportControl()
        {
            var control = new Import
            {
                DataContext = _importViewModel
            };
            _importDispatcher = control.Dispatcher;

            _materialConflictsViewModel = (MaterialConflictsViewModel)control.MaterialConflicts.DataContext;

            var materialConflictResolver = new MaterialConflictResolver(
                _materialConflictsViewModel.SetConflicts,
                _materialConflictsViewModel.CheckAllMaterialsMappedAsync,
                control.MaterialConflicts.AwaitContinueButtonClick,
                _materialConflictsViewModel.GetMappingResults);

            _importViewModel.MaterialConflictResolver = materialConflictResolver;
            return control;
        }

        public void Convert(
            List<IConversionOption> options,
            CancellationToken token,
            out Structure ubsm,
            out string sourcePath)
        {
            _materialConflictsViewModel.Initialize();
            _importDispatcher.Invoke(
                () =>
                {
                    // observable collections can only be updated from GUI thread
                    var collectionLock = new object();
                    BindingOperations.EnableCollectionSynchronization(_materialConflictsViewModel.Conflicts, collectionLock);
                    BindingOperations.EnableCollectionSynchronization(_materialConflictsViewModel.Materials, collectionLock);
                });
            var (structure, path) = ConvertAsync(token)
                .GetAwaiter()
                .GetResult();
            _importDispatcher.Invoke(
                () =>
                {
                    // observable collections can only be updated from GUI thread
                    BindingOperations.DisableCollectionSynchronization(_materialConflictsViewModel.Conflicts);
                    BindingOperations.DisableCollectionSynchronization(_materialConflictsViewModel.Materials);
                });

            ubsm = structure;
            sourcePath = path;
        }

        private async Task<(Structure, string)> ConvertAsync(CancellationToken token)
        {
            OnProgressChanged("Starting...", 0.0);

            _importViewModel.UpdateTitle("Materials");
            OnProgressChanged("Loading materials...", 0.0);
            var materials = await _ubsmDatabase.GetMaterialsAsync();
            _materialConflictsViewModel.SetMaterials(materials);
            OnProgressChanged("resolving material conflicts", 1.0);
            var mappedMaterials = await _importViewModel.GetMaterialMappingAsync(token);
            OnProgressChanged("materials mapped", 4.0);
            var ubsmMaterials = new List<Material>();
            foreach (var mappedMaterial in mappedMaterials)
            {
                var material = await _ubsmDatabase.GetMaterialAsync(mappedMaterial.UbsmId);
                ubsmMaterials.Add(material);
                Debug.WriteLine($"> UBSM material {material.Name.Default}");
            }

            OnProgressChanged("loaded materials", 5.0);

            for (var i = 1; i < 20; i++)
            {
                token.ThrowIfCancellationRequested();
                _importViewModel.UpdateTitle($"Running in loop {i}");

                await Task.Delay(100, CancellationToken.None);
                var percentage = (i + 1) * 5d;
                OnProgressChanged("Import: making progress...", percentage);
            }

            OnProgressChanged("All done", 100);

            var result = new Structure
            {
                PhysicalModel =
                {
                    Materials = ubsmMaterials
                }
            };

            return (result, null);
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
