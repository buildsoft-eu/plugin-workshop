using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using Example.API;
using Plugin.Example.Localization;
using Plugin.Example.Models;
using Plugin.Example.Services;

namespace Plugin.Example.ViewModels
{
    public class MaterialConflictsViewModel : ViewModelBase, IMaterialConflictResolver
    {
        public string ApiMaterialText => MaterialConflicts.ApiMaterial;
        public string ConflictTypeText => MaterialConflicts.Type;
        public string ContinueText => General.Continue;
        public string UbsmMaterialText => MaterialConflicts.UbsmMaterial;

        public bool CanContinue { get; private set; }

        public void Initialize()
        {
            CanContinue = false;
            OnPropertyChanged(nameof(CanContinue));
        }

        private void EnableContinuation()
        {
            CanContinue = true;
            OnPropertyChanged(nameof(CanContinue));
        }

        public ObservableCollection<MaterialConflictViewModel> Conflicts { get; } = new();

        public ObservableCollection<UbsmMaterialViewModel> Materials { get; } = new();

        public bool IsVisible { get; private set; }

        private void SetVisibility(bool value)
        {
            IsVisible = value;
            OnPropertyChanged(nameof(IsVisible));
        }

        public Func<Task> WaitForConflictResolutionCompletion { private get; set; }

        private void SetConflicts(IEnumerable<MaterialConflict> conflicts)
        {
            Conflicts.Clear();
            foreach (var conflict in conflicts.OrderBy(c => c.ApiMaterial.Name))
            {
                Conflicts.Add(new MaterialConflictViewModel(conflict));
            }
        }

        private void SetMaterials(IEnumerable<Database.MaterialOverviewItem> items)
        {
            Materials.Clear();
            foreach (var item in items)
            {
                Materials.Add(
                    new UbsmMaterialViewModel
                    {
                        Id = item.ID,
                        Name = item.Name.Default
                    });
            }
        }

        private IEnumerable<MaterialMapping> GetMappingResults()
        {
            return Conflicts.Select(ConvertToMapping);
        }

        private static MaterialMapping ConvertToMapping(MaterialConflictViewModel viewModel)
        {
            var data = viewModel.Data;
            if (data.UbsmMaterial.HasValue)
            {
                return new()
                {
                    ApiName = data.ApiMaterial.Name,
                    UbsmId = data.UbsmMaterial.Value
                };
            }

            var mappedTo = viewModel.MappedTo;
            return new()
            {
                ApiName = data.ApiMaterial.Name,
                UbsmId = mappedTo.Id
            };
        }

        private async Task CheckAllMaterialsMappedAsync()
        {
            await Conflicts;
            EnableContinuation();
        }

        public Task<IEnumerable<MaterialConflict>> DetermineConflictsAsync(IEnumerable<Database.MaterialOverviewItem> materials)
        {
            SetMaterials(materials);
            return Task.FromResult<IEnumerable<MaterialConflict>>(
                new[]
                {
                    new MaterialConflict
                    {
                        ConflictType = ConflictType.MissingMapping,
                        ApiMaterial = new Material{ Name = "Test Material 1" },
                        UbsmMaterial = null
                    },
                    new MaterialConflict
                    {
                        ConflictType = ConflictType.MissingMapping,
                        ApiMaterial = new Material{ Name = "Alpha test material 2" },
                        UbsmMaterial = null
                    }
                });
        }

        public async Task<IEnumerable<MaterialMapping>> ResolveConflictsAsync(IEnumerable<MaterialConflict> conflicts)
        {
            SetConflicts(conflicts);
            SetVisibility(true);
            await CheckAllMaterialsMappedAsync();
            await WaitForConflictResolutionCompletion();
            SetVisibility(false);
            return GetMappingResults();
        }
    }
}
