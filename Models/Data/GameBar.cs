using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

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
            }
            else
            {
                Tag = "Favorite";
            }

        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public IconElement Icon { get; set; }
        public ObservableCollection<GameBar> Children { get; set; }
        public Game Game { get; }
        private string[] _showTitle= new string[0];

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
                char[] vs = Title.ToCharArray();
                char ca=' ';
                while(ca == ' ')
                {
                    ca = vs[(new Random().Next(0, vs.Length - 1))];
                }
                char ca1 = ' ';
                while (ca1 == ' ' || ca1 == ca)
                {
                    ca1 = vs[(new Random().Next(0, vs.Length - 1))];
                }
                return new string[] { ca.ToString().ToUpper(), ca1.ToString().ToUpper() };
            }
        }
    }
}
