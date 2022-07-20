using MyWareHouse.Models.Data;
using MyWareHouse.Models.ThemeService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

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

        private Game _game;
        internal Game Game
        {
            get => _game;
            set => SetProperty(ref _game, value);
        }

        private string[] _titleChar = new string[] { "N", "O" };
        /// <summary>
        /// 无头图时，头图内展示的Char
        /// </summary>
        public string[] TitleChar
        {
            get => _titleChar;
            set => SetProperty(ref _titleChar, value);
        }

        private Visibility _headImageStatu = Visibility.Collapsed;
        public Visibility HeadImageStatu
        {
            get => _headImageStatu;
            set => SetProperty(ref _headImageStatu, value);
        }

        private Visibility _bgiStatu = Visibility.Collapsed;
        public Visibility BGIStatu
        {
            get => _bgiStatu;
            set => SetProperty(ref _bgiStatu, value);
        }

        private double _gameInfoBoxBackgroundOpacity = 1;
        public double GameInfoBoxBackgroundOpacity
        {
            get => _gameInfoBoxBackgroundOpacity;
            set => SetProperty(ref _gameInfoBoxBackgroundOpacity, value);
        }
    }
}
