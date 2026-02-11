using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RetroBar.Converters
{
    [ValueConversion(typeof(double), typeof(BitmapScalingMode))]
    public class SettingsToBitmapScalingModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double scale && scale > 1)
                return BitmapScalingMode.NearestNeighbor;

            return BitmapScalingMode.Linear;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
