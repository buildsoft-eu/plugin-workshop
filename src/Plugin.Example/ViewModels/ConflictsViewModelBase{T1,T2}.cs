using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Example.Models;
using Plugin.Example.Services;

namespace Plugin.Example.ViewModels
{
    public abstract class ConflictsViewModelBase<TConflictViewModel, TUbsm, TApi>
        : ViewModelWithContinueBase,
        IConflictResolver<TApi, TUbsm>
    where TConflictViewModel : IConflictViewModel
    {
        public string ConflictTypeText => Localization.Conflicts.Type;

        public void Initialize()
        {
            SetContinuation(false);
        }

        public ObservableCollection<TConflictViewModel> Conflicts { get; } = new();

        public ObservableCollection<UbsmMappingViewModel> Mappings { get; } = new();

        public Func<Task> WaitForConflictResolutionCompletion { private get; set; }

        private void SetConflicts(IEnumerable<Conflict<TApi>> conflicts)
        {
            Conflicts.Clear();
            foreach (var conflict in conflicts.OrderBy(GetSortField))
            {
                UbsmMappingViewModel mappedTo = null;
                if (conflict.Ubsm.HasValue)
                {
                    mappedTo = Mappings.FirstOrDefault(x => x.Id == conflict.Ubsm.Value);
                }
                Conflicts.Add(CreateConflictViewModel(conflict, mappedTo));
            }
        }

        protected abstract string GetSortField(Conflict<TApi> conflict);

        protected abstract TConflictViewModel CreateConflictViewModel(Conflict<TApi> conflict, UbsmMappingViewModel mappedTo);

        private void SetMappings(IEnumerable<TUbsm> items)
        {
            Mappings.Clear();
            foreach (var item in items)
            {
                Mappings.Add(CreateMappingViewModel(item));
            }
        }

        protected abstract UbsmMappingViewModel CreateMappingViewModel(TUbsm item);

        private IEnumerable<Mapping> GetMappingResults()
        {
            return Conflicts.Select(ConvertToMapping);
        }

        protected abstract Mapping ConvertToMapping(TConflictViewModel viewModel);

        private async Task CheckAllItemsMappedAsync()
        {
            await Conflicts;
            SetContinuation(true);
        }

        public Task<IEnumerable<Conflict<TApi>>> DetermineConflictsAsync(
            IEnumerable<TApi> apiItems,
            IEnumerable<TUbsm> ubsmItems)
        {
            SetMappings(ubsmItems);
            return CreateConflictsAsync(apiItems, ubsmItems);
        }

        protected abstract Task<IEnumerable<Conflict<TApi>>> CreateConflictsAsync(
            IEnumerable<TApi> apiItems,
            IEnumerable<TUbsm> ubsmItems);

        public async Task<IEnumerable<Mapping>> ResolveConflictsAsync(
            IEnumerable<Conflict<TApi>> conflicts,
            CancellationToken token)
        {
            SetConflicts(conflicts);
            SetVisibility(true);
            await CheckAllItemsMappedAsync()
                .TryCatchCancellationAsync(
                    token,
                    () => SetVisibility(false));
            await WaitForConflictResolutionCompletion()
                .TryCatchCancellationAsync(
                    token,
                    () => SetVisibility(false));
            SetVisibility(false);
            return GetMappingResults();
        }
    }
}
