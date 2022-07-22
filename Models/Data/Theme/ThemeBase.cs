using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MyWareHouse.Models.Data.Theme
{
    public class ThemeBase : BindableBase
    {
        /// <summary>
        /// 突出对比的颜色 一般为白色
        /// </summary>
        private Brush _fontColor;
        private Color _themFontColor;
        private Brush _themeColor;
        private Brush _themeColorLight;
        private Brush _themeColorDeep;
        private Color _themecolor;
        private Brush _background;
        private Brush _gameBarColor = new SolidColorBrush(Color.FromArgb(255, 255, 174, 82));

        public ThemeBase()
        {
        }

        /// <summary>
        /// 与主题相类似的颜色
        /// </summary>
        public Color ThemeFontColor
        {
            get => _themFontColor;
            set => SetProperty(ref _themFontColor, value);
        }
        /// <summary> 
        /// 游戏标识栏颜色 颜色默认为 255, 174, 82 的橙色
        /// </summary>
        public Brush GameBarColor
        {
            get { return _gameBarColor; }
            set { this.SetProperty(ref _gameBarColor, value); }
        }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public Brush FontColor { get
            { return _fontColor; }
            set
            {
                this.SetProperty(ref _fontColor, value);
            }
        }
        /// <summary>
        /// 主题颜色
        /// </summary>
        public Brush ThemeColor
        {
            get
            {
                return _themeColor;
            }
            set
            {
                this.SetProperty(ref _themeColor, value);
            }
        }
        /// <summary>
        /// 主题颜色
        /// </summary>
        public Brush ThemeColorLight
        {
            get
            {
                return _themeColorLight;
            }
            set
            {
                this.SetProperty(ref _themeColorLight, value);
            }
        }
        /// <summary>
        /// 主题颜色
        /// </summary>
        public Brush ThemeColorDeep
        {
            get
            {
                return _themeColorDeep;
            }
            set
            {
                this.SetProperty(ref _themeColorDeep, value);
            }
        }
        /// <summary>
        /// 主题颜色 返回color
        /// </summary>
        public Color ColorTheme
        {
            get => _themecolor;
            set => this.SetProperty(ref _themecolor, value);
        }
        /// <summary>
        /// 背景 可作为颜色或者是图片
        /// </summary>
        public Brush Background
        {
            get { return _background; }
            set
            {
                this.SetProperty(ref _background, value);
            }
        }
        /// <summary>
        /// 把颜色转换为Brush
        /// </summary>
        /// <param name="color">待转换颜色</param>
        /// <param name="opacity">透明度 1--不透明</param>
        /// <returns></returns>
        public Brush Color2Brush(Color color, double opacity = 1)
        {
            SolidColorBrush brush = new SolidColorBrush(color);
            brush.Opacity = opacity;
            return brush;
        }
    }
}
