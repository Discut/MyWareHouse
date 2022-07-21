using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MyWareHouse.Models.Data.Theme
{
    class AuroraTheme : ThemeBase
    {
        public AuroraTheme()
        {
            FontColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            ColorTheme = Color.FromArgb(255, 38, 122, 140);
            ThemeColor = new SolidColorBrush(Color.FromArgb(255, 38, 122, 140));

            this.GameBarColor = new SolidColorBrush(Color.FromArgb(255, 179, 169, 153));

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Background/4.jpg"));
            imageBrush.Stretch = Stretch.UniformToFill;
            this.Background = imageBrush;
        }
    }
}
