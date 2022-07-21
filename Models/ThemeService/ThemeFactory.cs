using MyWareHouse.Models.Data.Theme;
using Prism.Mvvm;
using System.Collections.Generic;

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
            //ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //ChangeThemeWith(localSettings.Values["ThemeName"] == null ? "" : localSettings.Values["ThemeName"].ToString());

            this.themeBase = new RainTheme();
        }

        public static ThemeFactory Instance { get { return Inner.themeFactory; } }

        /// <summary>
        /// 获取所有的主题实例
        /// </summary>
        /// <returns></returns>
        public IList<ThemeBase> GetAllThemes()
        {
            List<ThemeBase> themes = new List<ThemeBase>();
            themes.Add(new AnimeSkyTheme());
            themes.Add(new AuroraTheme());
            themes.Add(new RainTheme());
            themes.Add(new ShamrockTheme());

            return themes;
        }

        public void ChangeThemeWith(string themeName)
        {
            IList<ThemeBase> lists = GetAllThemes();

            foreach(ThemeBase theme in lists)
            {
                if (themeName == theme.GetType().Name)
                {
                    Theme = theme;
                    break;
                }
            }
            if (Theme == null)
                Theme = new RainTheme();
            else if (themeName != Theme.GetType().Name)
                Theme = new RainTheme();
        }

    }
}
