using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM.Analysis;
using BuildSoft.UBSM.Physical;

namespace Plugin.Example.Services
{
    public class UbsmDatabase : IUbsmDatabase
    {
        private List<Database.MaterialOverviewItem> _materials;
        private List<Database.ParametricSectionOverviewItem> _sections;

        public Task<IEnumerable<Database.MaterialOverviewItem>> GetMaterialsAsync()
        {
            if (_materials == null)
            {
                LoadMaterials();
            }

            return Task.FromResult(_materials.AsEnumerable());
        }

        private void LoadMaterials()
        {
            _materials = Database.GetAllMaterials()
                .Where(x => x.MaterialType == MaterialType.Steel)
                .OrderBy(x => x.Name.Default)
                .ToList();
        }

        public Task<Material> GetMaterialAsync(Guid id)
        {
            var material = Database.GetMaterial(id);
            return Task.FromResult(material);
        }

        public Task<IEnumerable<Database.ParametricSectionOverviewItem>> GetSectionsAsync()
        {
            if (_sections == null)
            {
                LoadSections();
            }

            return Task.FromResult(_sections.AsEnumerable());
        }

        private void LoadSections()
        {
            _sections = Database.GetAllParametricSections()
                .Where(x => x.SectionType == ParametricSectionType.SymmetricI)
                .OrderBy(x => x.Name.Default)
                .ToList();
        }

        public Task<ParametricSection> GetSectionAsync(Guid id)
        {
            var section = Database.GetParametricSection(id);
            return Task.FromResult(section);
        }

        public Task<MaterialProperties> GetMaterialPropertiesAsync(Guid id)
        {
            var material = Database.GetMaterialProperties(id);
            return Task.FromResult(material);
        }

        public Task<SectionProperties> GetSectionPropertiesAsync(Guid id)
        {
            var section = Database.GetSectionProperties(id);
            return Task.FromResult(section);
        }
    }
}
