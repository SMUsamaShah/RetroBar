using System;
using System.Windows.Data;
using System.Windows.Media;

namespace RetroBar.Converters
{
    [ValueConversion(typeof(bool), typeof(TextFormattingMode))]
    public class SettingsToTextFormattingModeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] is double scale && values[1] is bool smoothing)
            {
                return TextFormattingMode.Display;
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
