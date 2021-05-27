using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Example.Models;

namespace Plugin.Example.Services
{
    public interface IConflictResolver<TApi, in T>
    {
        Task<IEnumerable<Conflict<TApi>>> DetermineConflictsAsync(
            IEnumerable<TApi> apiMaterials,
            IEnumerable<T> materials);
        Task<IEnumerable<Mapping>> ResolveConflictsAsync(
            IEnumerable<Conflict<TApi>> conflicts,
            CancellationToken token);
    }
}
