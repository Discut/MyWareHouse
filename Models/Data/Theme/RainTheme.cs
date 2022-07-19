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
    class RainTheme : ThemeBase
    {
        public RainTheme()
        {
            this.FontColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.ColorTheme = Color.FromArgb(255, 25, 106, 113);
            this.ThemeColor = new SolidColorBrush(ColorTheme);

            this.GameBarColor = this.ThemeColor;

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Background/3.jpg"));
            imageBrush.Stretch = Stretch.UniformToFill;
            this.Background = imageBrush;
        }
    }
}
