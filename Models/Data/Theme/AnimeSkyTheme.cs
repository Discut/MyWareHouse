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
    class AnimeSkyTheme : ThemeBase
    {
        public AnimeSkyTheme()
        {
            FontColor = new SolidColorBrush(Color.FromArgb(255, 255, 255,255));
            ColorTheme = Color.FromArgb(255, 38, 122, 140);
            ThemeColor = new SolidColorBrush(Color.FromArgb(255, 252, 156, 139));

            this.GameBarColor = new SolidColorBrush(Color.FromArgb(255, 247, 201, 187));

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Background/animeSky.png"));
            imageBrush.Stretch = Stretch.UniformToFill;
            this.Background = imageBrush;
        }
    }
}
