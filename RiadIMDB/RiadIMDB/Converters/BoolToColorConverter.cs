using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace RiadIMDB.iOS.Converters
{
    public class BoolToColorConverter : IMvxValueConverter
    {
        UIColor _trueColor;
        UIColor _falseColor;

        public BoolToColorConverter(UIColor ifTrueColor, UIColor ifFalseColor)
        {
            _trueColor = ifTrueColor;
            _falseColor = ifFalseColor;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = (bool)value;
            return boolean ? _trueColor : _falseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
