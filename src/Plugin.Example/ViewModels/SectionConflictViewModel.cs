using Example.API;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public class SectionConflictViewModel : ConflictViewModelBase<Section>
    {
        public SectionConflictViewModel(Conflict<Section> data)
            : base(data)
        {
        }

        public override string Name => Data.Api.Name;
    }
}
