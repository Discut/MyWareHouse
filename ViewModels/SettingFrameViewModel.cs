using MyWareHouse.Models.Data.Theme;
using MyWareHouse.Models.ThemeService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MyWareHouse.ViewModels
{

    class SettingFrameViewModel : BindableBase
    {
        private ThemeFactory _theme;
        private string _text;
        private IList<ThemeBase> _themes;

        /// <summary>
        /// 获取主题实例
        /// </summary>
        public IList<ThemeBase> Themes
        {
            get => _themes;
            set => SetProperty(ref _themes, value);
        }

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
            Themes = Theme.GetAllThemes();
        }

        /// <summary>
        /// 主题切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ThemeItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is ThemeBase theme)
            {
                ThemeFactory.Instance.Theme = theme;
            }
        }
    }
}
