using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM.Physical;

namespace Plugin.Example.Services
{
    public class UbsmDatabase : IUbsmDatabase
    {
        private List<Database.MaterialOverviewItem> _materials;

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
    }
}
