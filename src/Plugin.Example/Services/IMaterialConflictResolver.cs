using System.Collections.Generic;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using Plugin.Example.Models;

namespace Plugin.Example.Services
{
    public interface IMaterialConflictResolver
    {
        Task<IEnumerable<MaterialConflict>> DetermineConflictsAsync(IEnumerable<Database.MaterialOverviewItem> materials);
        Task<IEnumerable<MaterialMapping>> ResolveConflictsAsync(IEnumerable<MaterialConflict> conflicts);
    }
}
