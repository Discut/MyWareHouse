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
                AllGames.AddRange(gameBar.Children.ToArray());
            }
        }
    }
}
