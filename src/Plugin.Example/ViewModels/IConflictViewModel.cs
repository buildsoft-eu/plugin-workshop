using System.ComponentModel;

namespace Plugin.Example.ViewModels
{
    public interface IConflictViewModel : INotifyPropertyChanged
    {
        UbsmMappingViewModel MappedTo { get; set; }
    }
}
