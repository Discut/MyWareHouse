using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MyWareHouse.Models.Data.Theme
{
    class LightTheme : ThemeBase
    {
        public LightTheme()
        {
            SolidColorBrush solid = new SolidColorBrush();
            solid.Color = Color.FromArgb(255, 0, 0, 0);
            this.FontColor = solid;

            SolidColorBrush solid1 = new SolidColorBrush();
            solid1.Color = Color.FromArgb(255, 234, 238, 241);
            this.ThemeColor = solid1;
        }
    }
}
