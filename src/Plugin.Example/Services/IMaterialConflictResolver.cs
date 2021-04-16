using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Example.Models;

namespace Plugin.Example.Services
{
    public interface IMaterialConflictResolver
    {
        Task<IEnumerable<MaterialConflict>> DetermineConflictsAsync();
        Task<IEnumerable<MaterialMapping>> ResolveConflictsAsync(IEnumerable<MaterialConflict> conflicts);
    }
}
