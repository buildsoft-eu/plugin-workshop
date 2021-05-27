namespace Plugin.Example.ViewModels
{
    public class ExportViewModel : ViewModelBase
    {
        public string DisplayTitle { get; private set; } = "Export control";

        public void UpdateTitle(string title)
        {
            DisplayTitle = title;
            OnPropertyChanged(nameof(DisplayTitle));
        }
    }
}
