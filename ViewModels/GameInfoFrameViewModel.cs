using MyWareHouse.Models.Data;
using MyWareHouse.Models.ThemeService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MyWareHouse.ViewModels
{
    public class GameInfoFrameViewModel : BindableBase
    {
        internal Action requestUpdate;

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
            IList<Tag> tags = new List<Tag>();
            tags.Add(new Tag() { Title = "tag1111111111111111" });
            tags.Add(new Tag() { Title = "tag2" });
            tags.Add(new Tag() { Title = "tag3" });
            Tags = tags;
            //ObservableCollection<Tag> tags = new ObservableCollection<Tag>();
            //tags.Add(new Tag() { Title = "tag1" });
            //tags.Add(new Tag() { Title = "tag2" });
            //tags.Add(new Tag() { Title = "tag3" });
            //Tags = tags;
        }

        private Game _game;
        internal Game Game
        {
            get => _game;
            set => SetProperty(ref _game, value);
        }

        private IList<Tag> _tags;
        /// <summary>
        /// 标签
        /// </summary>
        internal IList<Tag> Tags
        {
            get => _tags;
            set
            {
                //IList<Tag> tags = new List<Tag>();
                //foreach(Tag tag in value)
                //{
                //    tags.Add(tag);
                //}
                SetProperty(ref _tags, value);
            }
        }
        
        /// <summary>
        /// 反转可见性 用于替代绑定的 ！ 符号
        /// </summary>
        /// <param name="visibility"></param>
        /// <returns></returns>
        public Visibility ReverseVisibility(Visibility visibility)
        {
            if (visibility == Visibility.Collapsed)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
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
            set 
            {
                SetProperty(ref _headImageStatu, value);
                RaisePropertyChanged("IsShowSetHeadImage");
            }
        }

        private Visibility _bgiStatu = Visibility.Collapsed;
        public Visibility BGIStatu
        {
            get => _bgiStatu;
            set 
            {
                SetProperty(ref _bgiStatu, value);
                RaisePropertyChanged("IsShowSetBackgroundImage");
            }
        }

        private double _gameInfoBoxBackgroundOpacity = 1;
        public double GameInfoBoxBackgroundOpacity
        {
            get => _gameInfoBoxBackgroundOpacity;
            set => SetProperty(ref _gameInfoBoxBackgroundOpacity, value);
        }


        public Visibility IsShowSetHeadImage
        {
            get
            {
                if (HeadImageStatu == Visibility.Visible)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public Visibility IsShowSetBackgroundImage
        {
            get
            {
                if (BGIStatu == Visibility.Visible)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        internal void selectMenu_Opening(object sender, object e)
        {

        }

    }
}
