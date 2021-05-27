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

        public Settings Data { get; private set; } = new();

        public override void Load()
        {
            Data = _settingsRepository.Get();
            OnPropertyChanged(nameof(ExportConnections));
        }

        public override void Save()
        {
            _settingsRepository.Set(Data);
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
            get => Data.ExportWithConnections;
            set
            {
                Data.ExportWithConnections = value;
                OnPropertyChanged();
            }
        }

        public double PortalDistance
        {
            get => Data.PortalDistance;
            set
            {
                Data.PortalDistance = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Labels

        public string TitleText => Localization.Settings.Title;
        public string ExportConnectionsText => Localization.Settings.ExportConnections;
        public string PortalDistanceText => Localization.Settings.PortalDistance;

        #endregion
    }
}
