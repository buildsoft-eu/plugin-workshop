using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using Example.API;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public class SectionConflictsViewModel
        : ConflictsViewModelBase<SectionConflictViewModel, Database.ParametricSectionOverviewItem, Section>
    {
        public string ApiSectionText => Localization.Conflicts.ApiSection;
        public string UbsmSectionText => Localization.Conflicts.UbsmSection;

        protected override string GetSortField(Conflict<Section> conflict)
        {
            return conflict.Api.Name;
        }

        protected override SectionConflictViewModel CreateConflictViewModel(
            Conflict<Section> conflict,
            UbsmMappingViewModel mappedTo)
        {
            return new(conflict) { MappedTo = mappedTo };
        }

        protected override UbsmMappingViewModel CreateMappingViewModel(Database.ParametricSectionOverviewItem item)
        {
            return new() { Id = item.ID, DisplayName = item.Name.Default };
        }

        protected override Mapping ConvertToMapping(SectionConflictViewModel viewModel)
        {
            var data = viewModel.Data;
            if (data.Ubsm.HasValue)
            {
                return new Mapping
                {
                    ApiName = data.Api.Name,
                    UbsmId = data.Ubsm.Value
                };
            }

            var mappedTo = viewModel.MappedTo;
            return new Mapping
            {
                ApiName = data.Api.Name,
                UbsmId = mappedTo.Id
            };
        }

        protected override Task<IEnumerable<Conflict<Section>>> CreateConflictsAsync(
            IEnumerable<Section> apiItems,
            IEnumerable<Database.ParametricSectionOverviewItem> ubsmItems)
        {
            // first try to match by name
            var apiSectionNames = apiItems
                .Select(x => x.Name)
                .ToArray();
            var nameMatches = ubsmItems
                .Where(m => apiSectionNames.Contains(m.Name.Default))
                .ToDictionary(
                    m => m.Name.Default,
                    m => m.ID);

            // todo: access a mapping file and look for matching string-guid pairs
            var mapping = Enumerable.Empty<(string, Guid)>()
                .ToDictionary(
                    x => x.Item1,
                    x => x.Item2);

            var result = ConstructSectionConflicts(
                apiItems,
                mapping,
                nameMatches);

            return Task.FromResult(result);
        }

        private static IEnumerable<Conflict<Section>> ConstructSectionConflicts(
            IEnumerable<Section> apiSections,
            IReadOnlyDictionary<string, Guid> mapping,
            IReadOnlyDictionary<string, Guid> matchesByName)
        {
            foreach (var apiSection in apiSections)
            {
                if (mapping.TryGetValue(apiSection.Name, out var ubsmId))
                {
                    yield return new Conflict<Section>
                    {
                        ConflictType = ConflictType.Resolved,
                        Api = apiSection,
                        Ubsm = ubsmId
                    };
                    continue;
                }

                if (matchesByName.TryGetValue(apiSection.Name, out ubsmId))
                {
                    yield return new Conflict<Section>
                    {
                        ConflictType = ConflictType.Resolved,
                        Api = apiSection,
                        Ubsm = ubsmId
                    };
                    continue;
                }

                yield return new Conflict<Section>
                {
                    ConflictType = ConflictType.MissingMapping,
                    Api = apiSection,
                    Ubsm = null
                };
            }
        }
    }
}
