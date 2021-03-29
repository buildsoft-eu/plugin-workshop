using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Controls;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Visualisation;

namespace Plugin.Example
{
    public class Plugin : IUBSMConverter
    {
        #region Info

        public Guid ID => Guid.Parse("d63d73df-6703-4370-ae57-74fae91b2386");  // todo: pick a unique identifier

        public string Name => Localization.General.Name;  // todo: update localization resources

        public ExchangeDirection AllowedExchange => ExchangeDirection.ImportAndExport;  // todo: set supported directions

        public Color Color => new Color { R = 238, G = 187, B = 68 };  // todo: pick a color

        public string IconName => "logo.png";  // todo: point to your own icon in the Images folder that is set to output to bin

        public CultureInfo UICulture { get; set; }

        #endregion

        #region Export

        public string ExportDescription => Localization.Export.Description;

        public UserControl CreateExportControl()
        {
            throw new NotImplementedException();
        }

        public void ConvertBack(
            Structure ubsm,
            string sourcePath,
            List<IConversionOption> options,
            CancellationToken token)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Import

        public string ImportDescription => Localization.Import.Description;

        public UserControl CreateImportControl()
        {
            throw new NotImplementedException();
        }

        public void Convert(
            List<IConversionOption> options,
            CancellationToken token,
            out Structure ubsm,
            out string sourcePath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Progress

        public double Progress { get; private set; }

        public string ProgressInformation { get; private set; }

        public event EventHandler ProgressChanged;

        private void OnProgressChanged(
            double percentage,
            string information)
        {
            Progress = percentage;
            ProgressInformation = information;
            ProgressChanged?.Invoke(this, null);
        }

        #endregion

        #region Settings

        public UserControl CreateSettingsControl()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
