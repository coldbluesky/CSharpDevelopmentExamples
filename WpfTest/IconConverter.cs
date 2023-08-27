using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Drawing;
using FileOperations;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using FileOperations.Model;
namespace WpfTest
{
    public class IconConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Binding.DoNothing;
            //var handle = (SHFILEINFO)value;
            var bitmapSource = Imaging.CreateBitmapSourceFromHIcon((IntPtr)value, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
           
          
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
