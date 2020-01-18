using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace _03___View_Model_MVVM_Basic
{  
    /// <summary>
    /// Converts a full path to a specific image type of drive, folder or file
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        // Convert string to image
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            // By default, we presume an image
            var image = "Images/HDD.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/HDD.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/folder_close.png";
                    break;
            }

          


            // Ścieżka do pliku z obrazkami w projekcie 
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        // Convert image to orginal string
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}