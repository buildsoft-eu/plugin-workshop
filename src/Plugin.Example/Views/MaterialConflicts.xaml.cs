using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Example.ViewModels;

namespace Plugin.Example.Views
{
    /// <summary>
    /// Interaction logic for MaterialConflicts.xaml
    /// </summary>
    public partial class MaterialConflicts
    {
        public MaterialConflicts()
        {
            InitializeComponent();
            DataContext = new MaterialConflictsViewModel();
        }

        public async Task AwaitContinueButtonClick()
        {
            Debug.WriteLine("waiting for continue button click");
            await ContinueButton;
        }
    }
}
