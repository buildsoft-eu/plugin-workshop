using System.Collections.ObjectModel;
using System.Windows.Controls;
using Plugin.Example.ViewModels;
using Plugin.Example.Views;

namespace Plugin.Example
{
    public static class Extension
    {
        public static ButtonAwaiter GetAwaiter(this Button button)
        {
            return new() { Button = button };
        }

        public static MaterialConflictsSolvedAwaiter GetAwaiter(
            this ObservableCollection<MaterialConflictViewModel> collection)
        {
            return new() { Conflicts = collection };
        }
    }
}
