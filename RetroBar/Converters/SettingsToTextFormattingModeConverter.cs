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
                // Non-integer scales above 1× (1.25×, 1.5×, 1.75×…) use Ideal so vector
                // text scales smoothly without blur. Integer scales (1×, 2×, 3×…) use
                // Display for retro pixel-grid hinting; BitmapCache + NearestNeighbor
                // handles the crisp upscaling for those.
                bool useIdeal = scale > 1 && scale % 1 != 0;
                return useIdeal ? TextFormattingMode.Ideal : TextFormattingMode.Display;
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
