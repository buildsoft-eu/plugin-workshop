using BuildSoft.BIMExpert.Plugin;
using Plugin.Workshop.ViewModels;

namespace Plugin.Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Example.ApiPlugin _apiPlugin;
        private readonly MainWindowViewModel _vm;

        public MainWindow()
        {
            _apiPlugin = new Example.ApiPlugin();
            DataContext = _vm = new MainWindowViewModel();
            InitializeComponent();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            _vm.SetPluginDisplayInfo(
                _apiPlugin.IconName,
                _apiPlugin.Color);
            _vm.SetPluginText(
                _apiPlugin.Name,
                _apiPlugin.ImportDescription,
                _apiPlugin.ExportDescription);
            _vm.SetPluginCommands(
                _apiPlugin.Convert,
                _apiPlugin.ConvertBack);

            PluginSettings.Content = _apiPlugin.CreateSettingsControl();
            PluginImport.Content = _apiPlugin.CreateImportControl();
            PluginExport.Content = _apiPlugin.CreateExportControl();

            _apiPlugin.ProgressChanged += ApiPluginProgressChanged;
        }

        private void ApiPluginProgressChanged(object sender, System.EventArgs e)
        {
            this.InvokeWPF(
                () => _vm.UpdateProgress(
                    _apiPlugin.ProgressInformation,
                    _apiPlugin.Progress));
        }
    }
}
