using MyWareHouse.Models.Data;
using MyWareHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWareHouse.Models.GameService;
using MyWareHouse.Models.GameService.Implement;

namespace MyWareHouse.ViewModels
{
    class WarehouseIndexFrameViewModel
    {
        public List<GameBar> AllGames { get; set; }

        public List<GameBar> LastPlyGames { get; set; }

        public WarehouseIndexFrameViewModel()
        {
            this.AllGames = new List<GameBar>();
            this.LastPlyGames = new List<GameBar>();


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
