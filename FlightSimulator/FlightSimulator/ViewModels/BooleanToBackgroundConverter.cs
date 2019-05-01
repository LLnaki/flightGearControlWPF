using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// This class provides with converter from background collor of some control.
    /// </summary>
    public class BooleanToBackgroundConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool && (bool)value == true)
                return Brushes.PaleVioletRed;
            return Brushes.White;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is SolidColorBrush && (SolidColorBrush)value == Brushes.PaleVioletRed)
                return true;
            return false;
        }
    }
}
