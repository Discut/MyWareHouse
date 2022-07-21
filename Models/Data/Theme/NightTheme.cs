using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MyWareHouse.Models.Data.Theme
{
    class NightTheme : ThemeBase
    {
        public NightTheme()
        {
            SolidColorBrush solid = new SolidColorBrush();
            solid.Color = Color.FromArgb(255, 255, 255, 255);
            this.FontColor = solid;

            SolidColorBrush solid1 = new SolidColorBrush();
            solid1.Color = Color.FromArgb(255, 44, 47, 59);
            this.ThemeColor = solid1;
        }
    }
}
