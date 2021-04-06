using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using UbsmColor = BuildSoft.UBSM.Visualisation.Color;

namespace Plugin.Workshop.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (!(value is UbsmColor ubsmColor))
            {
                return new SolidColorBrush(Colors.Transparent);
            }

            return new SolidColorBrush(
                Color.FromArgb(
                    (byte)ubsmColor.Alpha,
                    (byte)ubsmColor.R,
                    (byte)ubsmColor.G,
                    (byte)ubsmColor.B));
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
