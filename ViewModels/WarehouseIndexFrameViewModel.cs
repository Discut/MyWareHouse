﻿using MyWareHouse.Models.Data;
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

        public WarehouseIndexFrameViewModel()
        {
            this.AllGames = new List<GameBar>();
            this.LastPlyGames = new List<GameBar>();
            ThemeFactory = ThemeFactory.Instance;


            IList<GameBar> games = GameServiceFactory.GetGameGetterService().GetGameBarList();

            foreach(GameBar gameBar in games)
            {
                GameBar[] gameBars = gameBar.Children.ToArray();
                AllGames.AddRange(gameBars);
            }

            IList<IDictionary<string, object>> lists = GameServiceFactory.GetGameGetterService().GetAllPlays();

            foreach (Dictionary<string, object> dic in lists)
            {
                foreach (GameBar gameBar in AllGames)
                {
                    if (dic["gameId"] as string == gameBar.Game.Id)
                    {   if (gameBar.play.DayOfYear == 1)
                        {
                            gameBar.play = Convert.ToDateTime(dic["playTime"].ToString());
                            LastPlyGames.Add(gameBar);
                        }
                    }
                }
                
            }
            LastPlyGames.Sort((GameBar g1, GameBar g2) =>
            {
                return DateTime.Compare(g2.play, g1.play);
            });



        }
    }
}
