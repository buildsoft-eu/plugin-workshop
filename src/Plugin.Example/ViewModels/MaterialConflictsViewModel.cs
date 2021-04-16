using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using Plugin.Example.Localization;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public class MaterialConflictsViewModel : ViewModelBase
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

        public void SetConflicts(IEnumerable<MaterialConflict> conflicts)
        {
            Conflicts.Clear();
            foreach (var conflict in conflicts.OrderBy(c => c.ApiMaterial.Name))
            {
                Conflicts.Add(new MaterialConflictViewModel(conflict));
            }
        }

        public void SetMaterials(IEnumerable<Database.MaterialOverviewItem> items)
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

        public IEnumerable<MaterialMapping> GetMappingResults()
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

        public async Task CheckAllMaterialsMappedAsync()
        {
            await Conflicts;
            EnableContinuation();
        }
    }
}
