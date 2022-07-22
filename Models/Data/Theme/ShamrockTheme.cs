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
    class ShamrockTheme : ThemeBase
    {

        public ShamrockTheme()
        {
            FontColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            ThemeColor = new SolidColorBrush(Color.FromArgb(255, 89, 143, 81));
            ColorTheme = Color.FromArgb(255, 89, 143, 81);
            ThemeFontColor = Color.FromArgb(255, 50, 87, 45);

            GameBarColor = new SolidColorBrush(Color.FromArgb(255, 68, 117, 61));

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Background/2.jpg"));
            imageBrush.Stretch = Stretch.UniformToFill;
            this.Background = imageBrush;
        }
    }
}
