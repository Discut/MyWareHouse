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
            SolidColorBrush solid = new SolidColorBrush();
            solid.Color = Color.FromArgb(255, 255, 255, 255);
            this.FontColor = solid;

            SolidColorBrush solid1 = new SolidColorBrush();
            solid1.Color = Color.FromArgb(255, 76, 128, 69);
            this.ThemeColor = solid1;

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Background/1.jpeg"));
            imageBrush.Stretch = Stretch.UniformToFill;
            this.Background = imageBrush;
        }
    }
}
