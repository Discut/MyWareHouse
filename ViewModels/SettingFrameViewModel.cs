using MyWareHouse.Models.Data.Theme;
using MyWareHouse.Models.ThemeService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MyWareHouse.ViewModels
{

    class SettingFrameViewModel : BindableBase
    {
        private ThemeFactory _theme;
        private string _text;

        public string Text
        {
            get { return _text; }
            set { this.SetProperty(ref _text, value); }
        }

        public ThemeFactory Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                this.SetProperty(ref _theme, value);
            }
        }

        public SettingFrameViewModel()
        {
            
            Theme = ThemeFactory.Instance;
            Text = "ceshi1";
        }

    }
}
