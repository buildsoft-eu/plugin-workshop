using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Example.ViewModels;

namespace Plugin.Example.Views
{
    /// <summary>
    /// Interaction logic for LoadFromApi.xaml
    /// </summary>
    public partial class LoadFromApi
    {
        public LoadFromApi()
        {
            InitializeComponent();
            DataContext = new LoadFromApiViewModel();
        }

        public async Task AwaitContinueButtonClick()
        {
            Debug.WriteLine("waiting for continue button click");
            await ContinueButton;
        }
    }
}
