using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildSoft.Linq;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Physical;
using Plugin.Example.Models;
using ApiMaterial = Example.API.Material;
using Text = Plugin.Example.Localization.Import;

namespace Plugin.Example.Services
{
    public class ImportService
    {
        private readonly IApiLoader _apiLoader;
        private readonly IMaterialConflictResolver _materialConflictResolver;
        private readonly IUbsmDatabase _database;

        private const double ProgressStart = 0.0;
        private const double ModelLoaded = 2.0;
        private const double MaterialsLoaded = 5.0;
        private const double MaterialConflictsDetermined = 7.0;
        private const double MaterialsMapped = 10.0;

        private double _currentProgressValue;
        private string _currentProgressText = "";

        public ImportService(
            IApiLoader apiLoader,
            IMaterialConflictResolver materialConflictResolver,
            IUbsmDatabase database)
        {
            _apiLoader = apiLoader;
            _materialConflictResolver = materialConflictResolver;
            _database = database;
        }

        public async Task<(Structure, string)> RunAsync(
            Action<string> updateTitle,
            IProgress<(string, double)> progress,
            CancellationToken token)
        {
            updateTitle(Text.LoadModelTitle);
            ReportProgress(progress, Text.FetchModelProgress, ProgressStart);
            var model = await _apiLoader.LoadAsync();
            ReportProgress(progress, Text.ModelLoadedProgress, ModelLoaded);

            updateTitle(Text.MappingMaterialsTitle);
            var apiMaterials = model.Portals
                .SelectMany(g => new[] { g.Beam.Material, g.Column.Material });
            var mappedMaterials = await GetMaterialMappingAsync(
                apiMaterials,
                progress,
                token);
            ReportProgress(progress, Text.MaterialsMapped, MaterialsMapped);

            updateTitle(Text.MappingSectionsTitle);
            // todo: section mapping

            // todo: bolt mapping

            // todo: create physical model
            var ubsmMaterials = new List<Material>();
            foreach (var mappedMaterial in mappedMaterials)
            {
                var material = await _database.GetMaterialAsync(mappedMaterial.UbsmId);
                ubsmMaterials.Add(material);
                Debug.WriteLine($"> UBSM material {material.Name.Default}");
            }
            var physicalModel = new Model
            {
                Materials = ubsmMaterials
            };

            // todo: create analytical model

            // todo: create loads

            // todo: remove dummy progress loop
            for (var i = 1; i < 20; i++)
            {
                token.ThrowIfCancellationRequested();
                updateTitle($"Running in loop {i}");

                await Task.Delay(100, CancellationToken.None);
                var percentage = (i + 1) * 5d;
                progress.Report(("Import: making progress...", percentage));
            }

            var result = new Structure
            {
                PhysicalModel = physicalModel
            };

            return (result, null);
        }

        internal async Task<List<MaterialMapping>> GetMaterialMappingAsync(
            IEnumerable<ApiMaterial> apiMaterials,
            IProgress<(string, double)> progress,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            ReportProgress(progress, Text.LoadingMaterials);
            var materials = await _database.GetMaterialsAsync();

            token.ThrowIfCancellationRequested();
            ReportProgress(progress, Text.ProcessingConflicts, MaterialsLoaded);
            var conflicts = await _materialConflictResolver.DetermineConflictsAsync(materials);
            if (conflicts.IsNullOrEmpty())
            {
                return new List<MaterialMapping>();
            }

            token.ThrowIfCancellationRequested();
            ReportProgress(progress, MaterialConflictsDetermined);
            var mapping = await _materialConflictResolver.ResolveConflictsAsync(conflicts);
            return mapping.ToList();
        }

        private void ReportProgress(
            IProgress<(string, double)> progress,
            string text)
        {
            ReportProgress(progress, text, _currentProgressValue);
        }

        private void ReportProgress(
            IProgress<(string, double)> progress,
            double value)
        {
            ReportProgress(progress, _currentProgressText, value);
        }

        private void ReportProgress(
            IProgress<(string, double)> progress,
            string text,
            double value)
        {
            _currentProgressText = text;
            _currentProgressValue = value;
            progress.Report((text, value));
        }
    }
}
