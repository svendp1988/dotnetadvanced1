using System;
using System.Globalization;
using System.Windows.Data;

namespace Exercise2.Converters
{
    public class RatingStarsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var output = "";
            for (var i = 0; i < (int) value; i++)
            {
                output += "*";
            }

            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Length;
        }
    }
}
