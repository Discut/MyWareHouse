using MyWareHouse.Models.Data;
using MyWareHouse.Models.Data.Factory;
using MyWareHouse.Models.ThemeService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace MyWareHouse.ViewModels
{
    class IndexGameShowFrameViewModel : BindableBase
    {
        private ThemeFactory _theme = ThemeFactory.Instance;
        /// <summary>
        /// 主题工厂
        /// </summary>
        public ThemeFactory ThemeFactory
        {
            get { return _theme; }
            set { SetProperty(ref _theme, value); }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }


        private System.Collections.ObjectModel.ObservableCollection<GameBar> _gameBarItem = new System.Collections.ObjectModel.ObservableCollection<GameBar>();

        public System.Collections.ObjectModel.ObservableCollection<GameBar> GameBarItem
        {
            get => _gameBarItem;
            set => SetProperty(ref _gameBarItem, value);
        }

        public IndexGameShowFrameViewModel()
        {
        }

        internal void init(GameBar target)
        {
            foreach (GameBar game in target.Children)
            {
                game.TitleColor = ThemeFactory.Theme.GameBarColor;
                GameBarItem.Add(game);
            }
        }

        
    }
}
