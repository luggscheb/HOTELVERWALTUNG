using Hotel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMAUIApp.Models.Converter
{
    internal class CategoryConverter : IValueConverter
    {
        
        public object Convert(object value,Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (int)(Category)value;
            }
            return (int)Category.notSpecified;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Category)(int)value;
            }
            return Category.notSpecified;
        }
    }
}
