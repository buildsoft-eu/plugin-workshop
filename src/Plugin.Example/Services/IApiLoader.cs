using System.Threading;
using System.Threading.Tasks;
using Example.API;

namespace Plugin.Example.Services
{
    public interface IApiLoader
    {
        Task<Model> LoadAsync(CancellationToken token);
    }
}
