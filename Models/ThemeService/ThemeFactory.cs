using MyWareHouse.Models.Data.Theme;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.ThemeService
{
    public class ThemeFactory : BindableBase
    {
        private ThemeBase themeBase;
        public ThemeBase Theme
        {
            get
            {
                return themeBase;
            }
            set
            {
                this.SetProperty(ref themeBase, value);
            }
        }
        private static class Inner
        {
            public static ThemeFactory themeFactory = new ThemeFactory();
        }
        private ThemeFactory() {
            this.themeBase = new RainTheme();
        }

        public static ThemeFactory Instance { get { return Inner.themeFactory; } }
    }
}
