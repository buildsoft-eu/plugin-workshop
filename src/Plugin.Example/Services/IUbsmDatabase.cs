using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM.Analysis;
using BuildSoft.UBSM.Physical;

namespace Plugin.Example.Services
{
    public interface IUbsmDatabase
    {
        Task<IEnumerable<Database.MaterialOverviewItem>> GetMaterialsAsync();
        Task<Material> GetMaterialAsync(Guid id);
        Task<IEnumerable<Database.ParametricSectionOverviewItem>> GetSectionsAsync();
        Task<ParametricSection> GetSectionAsync(Guid id);
        Task<MaterialProperties> GetMaterialPropertiesAsync(Guid id);
        Task<SectionProperties> GetSectionPropertiesAsync(Guid id);
    }
}
