using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace RiadIMDB.iOS.Converters
{
    public class ImagePathConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = value.ToString();
            return $"res:{path}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
