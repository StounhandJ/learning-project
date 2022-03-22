using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace InventoryOfEquipment.Converters
{
    [ValueConversion(typeof(bool), typeof(Color))]
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var converter = new BrushConverter();
            return (Brush)converter.ConvertFromString(value != null && (bool) value?"#00B0BD":"#A3A0A0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}