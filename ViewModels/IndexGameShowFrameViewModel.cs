using MyWareHouse.Models.Data;
using MyWareHouse.Models.Data.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace MyWareHouse.ViewModels
{
    class IndexGameShowFrameViewModel
    {

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }


        public System.Collections.ObjectModel.ObservableCollection<GameBar> gameBarItem;

        Double w = 300;

        public IndexGameShowFrameViewModel()
        {
            this.gameBarItem = new System.Collections.ObjectModel.ObservableCollection<GameBar>();
            //this.gameBarItem.Add(new GameBarItem() { Title = "游戏", Width = w ,Favorite="未设置收藏夹"});
            //this.gameBarItem.Add(new GameBarItem() { Title = "游戏游戏", Width = w,Favorite = "置收藏夹" });
            //this.gameBarItem.Add(new GameBarItem() { Title = "LBS", Width = w,Favorite = "收藏夹" });

            //this.gameBarItem.Add(new GameBarItem() { Title = "DSFS", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "1", Width = w });
            //this.gameBarItem.Add(new GameBarItem() { Title = "2", Width = w });

        }

        internal void init(GameBar target)
        {
            foreach (GameBar game in target.Children)
                gameBarItem.Add(game);
        }

        
    }

    //public class GameBarItem
    //{
    //    public string Title;
    //    public string Favorite;
    //    public Double Width;
    //}
}
