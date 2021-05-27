namespace Plugin.Example.ViewModels
{
    public class ImportViewModel : ViewModelBase
    {
        public string DisplayTitle { get; private set; } = "Import control";

        public void UpdateTitle(string title)
        {
            DisplayTitle = title;
            OnPropertyChanged(nameof(DisplayTitle));
        }
    }
}
