using Plugin.Example.Models;
using Plugin.Example.Services;

namespace Plugin.Example.ViewModels
{
    public class SettingsViewModel : BuildSoft.BIMExpert.Plugin.SettingsViewModel
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsViewModel(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        #region Base class implementations

        private Settings _settings = new Settings();

        public override void Load()
        {
            _settings = _settingsRepository.Get();
            OnPropertyChanged(nameof(ExportConnections));
        }

        public override void Save()
        {
            _settingsRepository.Set(_settings);
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }

        public override void Redo()
        {
            throw new System.NotImplementedException();
        }

        // toggles the enabled state of the buttons
        public override bool CanSave => true;
        public override bool CanUndo => false;
        public override bool CanRedo => false;

        #endregion

        #region Properties

        public bool ExportConnections
        {
            get => _settings.ExportWithConnections;
            set
            {
                _settings.ExportWithConnections = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Labels

        public string TitleText => Localization.Settings.Title;
        public string ExportConnectionsText => Localization.Settings.ExportConnections;

        #endregion
    }
}
