using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using Example.API;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public class MaterialConflictsViewModel
        : ConflictsViewModelBase<MaterialConflictViewModel, Database.MaterialOverviewItem, Material>
    {
        public string ApiMaterialText => Localization.Conflicts.ApiMaterial;
        public string UbsmMaterialText => Localization.Conflicts.UbsmMaterial;

        protected override string GetSortField(Conflict<Material> conflict)
        {
            return conflict.Api.Name;
        }

        protected override MaterialConflictViewModel CreateConflictViewModel(
            Conflict<Material> conflict,
            UbsmMappingViewModel mappedTo)
        {
            return new(conflict) { MappedTo = mappedTo };
        }

        protected override UbsmMappingViewModel CreateMappingViewModel(Database.MaterialOverviewItem item)
        {
            return new() { Id = item.ID, DisplayName = item.Name.Default };
        }

        protected override Mapping ConvertToMapping(MaterialConflictViewModel viewModel)
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

        protected override Task<IEnumerable<Conflict<Material>>> CreateConflictsAsync(
            IEnumerable<Material> apiItems,
            IEnumerable<Database.MaterialOverviewItem> ubsmItems)
        {
            // first try to match by name
            var apiMaterialNames = apiItems
                .Select(x => x.Name)
                .ToArray();
            var nameMatches = ubsmItems
                .Where(m => apiMaterialNames.Contains(m.Name.Default))
                .ToDictionary(
                    m => m.Name.Default,
                    m => m.ID);

            // todo: access a mapping file and look for matching string-guid pairs
            var mapping = Enumerable.Empty<(string, Guid)>()
                .ToDictionary(
                    x => x.Item1,
                    x => x.Item2);

            var result = ConstructMaterialConflicts(
                apiItems,
                mapping,
                nameMatches);

            return Task.FromResult(result);
        }

        private static IEnumerable<Conflict<Material>> ConstructMaterialConflicts(
            IEnumerable<Material> apiMaterials,
            IReadOnlyDictionary<string, Guid> mapping,
            IReadOnlyDictionary<string, Guid> matchesByName)
        {
            foreach (var apiMaterial in apiMaterials)
            {
                if (mapping.TryGetValue(apiMaterial.Name, out var ubsmId))
                {
                    yield return new Conflict<Material>
                    {
                        ConflictType = ConflictType.Resolved,
                        Api = apiMaterial,
                        Ubsm = ubsmId
                    };
                    continue;
                }

                if (matchesByName.TryGetValue(apiMaterial.Name, out ubsmId))
                {
                    yield return new Conflict<Material>
                    {
                        ConflictType = ConflictType.Resolved,
                        Api = apiMaterial,
                        Ubsm = ubsmId
                    };
                    continue;
                }

                yield return new Conflict<Material>
                {
                    ConflictType = ConflictType.MissingMapping,
                    Api = apiMaterial,
                    Ubsm = null
                };
            }
        }
    }
}
