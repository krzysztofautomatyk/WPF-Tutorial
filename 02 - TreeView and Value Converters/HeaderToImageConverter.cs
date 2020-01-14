using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.IO;

namespace _02___TreeView_and_Value_Converters
{        
    /// <summary>
    /// Converts a full path to a specific image type of drive, folder or file
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        // Convert string to image
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the full path
            var path = (string)value;

            // If the path is null, ignore
            if (path == null)
                return null;

            // Get the name of the file/folder
            var name = MainWindow.GetFileFolderName(path);

          
            // By default, we presume an image
            var image = "Images/HDD.png";

            // If the name is blank, we presume it's a drive as we cannont have a blank file or folder name
            if (string.IsNullOrEmpty(name))
                image= "Images/HDD.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/folder_close.png";
            else image = "Images/file.png";


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
