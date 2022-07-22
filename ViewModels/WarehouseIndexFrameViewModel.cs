using MyWareHouse.Models.Data;
using MyWareHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWareHouse.Models.GameService;
using MyWareHouse.Models.GameService.Implement;
using Prism.Mvvm;
using MyWareHouse.Models.ThemeService;

namespace MyWareHouse.ViewModels
{
    class WarehouseIndexFrameViewModel : BindableBase
    {
        private string _accountName;
        private string _weekTitle;
        private string _hello;
        /// <summary>
        /// 问好
        /// </summary>
        public string Hello { 
            get {
                return _hello;
            }
            set
            {
                this.SetProperty(ref _hello, value);
            } 
        }
        /// <summary>
        /// 星期几
        /// </summary>
        public string WeekTitle
        {
            get => _weekTitle;
            set
            {
                this.SetProperty(ref _weekTitle, value);
            }
        }

        public string AcountName
        {
            get { return _accountName; }
            set { this.SetProperty(ref _accountName, value); }
        }

        public List<GameBar> AllGames { get; set; }

        public List<GameBar> LastPlyGames { get; set; }

        private ThemeFactory _theme;
        /// <summary>
        /// 主题工厂
        /// </summary>
        public ThemeFactory ThemeFactory
        {
            get { return _theme; }
            set { SetProperty(ref _theme, value); }
        }

        public GameBar LastPlayGame { get; set; }

        public WarehouseIndexFrameViewModel()
        {
            this.AllGames = new List<GameBar>();
            this.LastPlyGames = new List<GameBar>();
            ThemeFactory = ThemeFactory.Instance;

            // 获取用于生成侧边栏的游戏数据资源
            IList<GameBar> games = GameServiceFactory.GetGameGetterService().GetGameBarList();
            // 在这里 通过for循环间接获取了所有游戏
            foreach(GameBar gameBar in games)
            {
                GameBar[] gameBars = gameBar.Children.ToArray();
                AllGames.AddRange(gameBars);
            }


            // 获取游戏最近运行的日期
            foreach(GameBar gameBar in AllGames)
            {
                string date = GameServiceFactory.GetGameGetterService().GetGamePlay(gameBar.Game);
                if (date != null)
                {
                    gameBar.play = Convert.ToDateTime(date);
                    LastPlyGames.Add(gameBar);
                }
                else
                    continue;
            }
            LastPlyGames.Sort((GameBar g1, GameBar g2) =>
            {
                return DateTime.Compare(g2.play, g1.play);
            });

            // 将最近的一个游戏单独分离出来
            LastPlayGame = LastPlyGames[0];
            LastPlyGames.RemoveAt(0);
            

        }
    }
}
