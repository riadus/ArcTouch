using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace RiadIMDB.iOS.Converters
{
    public class ReverseBooleanConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = (bool)value;
            return !boolean;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
