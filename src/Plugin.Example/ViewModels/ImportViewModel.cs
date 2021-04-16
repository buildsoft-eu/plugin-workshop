using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildSoft.Linq;
using Plugin.Example.Models;
using Plugin.Example.Services;

namespace Plugin.Example.ViewModels
{
    public class ImportViewModel : ViewModelBase
    {
        public string DisplayTitle { get; private set; } = "Import control";

        public bool ShowMaterialConflictsControl { get; private set; }

        public IMaterialConflictResolver MaterialConflictResolver { get; set; }

        public void UpdateTitle(string title)
        {
            DisplayTitle = title;
            OnPropertyChanged(nameof(DisplayTitle));
        }

        private void UpdateMaterialConflicts(bool visible)
        {
            ShowMaterialConflictsControl = visible;
            OnPropertyChanged(nameof(ShowMaterialConflictsControl));
        }

        public async Task<List<MaterialMapping>> GetMaterialMappingAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var materialConflicts = await MaterialConflictResolver.DetermineConflictsAsync();
            if (materialConflicts.IsNullOrEmpty())
            {
                return new List<MaterialMapping>();
            }

            token.ThrowIfCancellationRequested();
            UpdateMaterialConflicts(true);
            var mapping = await MaterialConflictResolver.ResolveConflictsAsync(materialConflicts);
            UpdateMaterialConflicts(false);
            return mapping.ToList();
        }
    }
}
