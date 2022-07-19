using MyWareHouse.Models.ThemeService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MyWareHouse.Models.Data
{
    class GameBar
    {
        public GameBar(Game game) {
            if (null != game)
            {
                this.Game = game;
                Title = game.Name;
                Tag = "Game";
                Id = game.Id;
            }
            else
            {
                Tag = "Favorite";
            }

            TitleColor = ThemeFactory.Instance.Theme.GameBarColor;

        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public IconElement Icon { get; set; }
        public ObservableCollection<GameBar> Children { get; set; }
        public Game Game { get; }
        public GameBar Myself { get { return this; } }
        private string[] _showTitle= new string[0];
        public DateTime play;
        public Brush TitleColor;

        public string[] ShowTitle { 
            get
            {
                if (_showTitle.Length == 0)
                    _showTitle = GetChar;
                return _showTitle;
            }
        }

        private string[] GetChar
        {
            get
            {
                if (Title.Length == 0)
                    return new string[] { "N", "O" };
                if (Title.Length == 1)
                    return new string[] { Title.ToCharArray()[0].ToString(), Title.ToCharArray()[0].ToString() };
                char[] vs = Title.ToCharArray();
                char ca=' ';
                while(ca == ' ')
                {
                    ca = vs[(new Random().Next(0, vs.Length))];
                }
                char ca1 = ' ';
                while (ca1 == ' ' || ca1 == ca)
                {
                    ca1 = vs[(new Random().Next(0, vs.Length))];
                }
                return new string[] { ca.ToString().ToUpper(), ca1.ToString().ToUpper() };
            }
        }
    }
}
