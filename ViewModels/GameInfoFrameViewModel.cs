using MyWareHouse.Models.ThemeService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.ViewModels
{
    public class GameInfoFrameViewModel : BindableBase
    {
        private ThemeFactory _theme;
        /// <summary>
        /// 主题工厂
        /// </summary>
        public ThemeFactory ThemeFactory
        {
            get { return _theme; }
            set { SetProperty(ref _theme, value); }
        }

        public GameInfoFrameViewModel()
        {
            ThemeFactory = ThemeFactory.Instance;
        }
    }
}
