using Plugin.Example.Localization;

namespace Plugin.Example.ViewModels
{
    public class ViewModelWithContinueBase : ViewModelBase
    {
        public string ContinueText => General.Continue;

        public bool CanContinue { get; private set; }

        protected void SetContinuation(bool value)
        {
            CanContinue = value;
            OnPropertyChanged(nameof(CanContinue));
        }

        public bool IsVisible { get; private set; }

        protected void SetVisibility(bool value)
        {
            IsVisible = value;
            OnPropertyChanged(nameof(IsVisible));
        }
    }
}
