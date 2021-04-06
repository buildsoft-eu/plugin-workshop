using BuildSoft.BIMExpert.Plugin;
using Plugin.Workshop.ViewModels;

namespace Plugin.Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Example.Plugin _plugin;
        private readonly MainWindowViewModel _vm;

        public MainWindow()
        {
            _plugin = new Example.Plugin();
            DataContext = _vm = new MainWindowViewModel();
            InitializeComponent();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            _vm.SetPluginDisplayInfo(
                _plugin.IconName,
                _plugin.Color);
            _vm.SetPluginText(
                _plugin.Name,
                _plugin.ImportDescription,
                _plugin.ExportDescription);
            _vm.SetPluginCommands(
                _plugin.Convert,
                _plugin.ConvertBack);

            PluginSettings.Content = _plugin.CreateSettingsControl();
            PluginImport.Content = _plugin.CreateImportControl();
            PluginExport.Content = _plugin.CreateExportControl();

            _plugin.ProgressChanged += PluginProgressChanged;
        }

        private void PluginProgressChanged(object sender, System.EventArgs e)
        {
            this.InvokeWPF(
                () => _vm.UpdateProgress(
                    _plugin.ProgressInformation,
                    _plugin.Progress));
        }
    }
}
