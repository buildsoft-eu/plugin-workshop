using Example.API;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public class MaterialConflictViewModel : ConflictViewModelBase<Material>
    {
        public MaterialConflictViewModel(Conflict<Material> data)
            : base(data)
        {
        }

        public override string Name => Data.Api.Name;
    }
}
