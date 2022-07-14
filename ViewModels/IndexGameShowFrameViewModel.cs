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
        public System.Collections.ObjectModel.ObservableCollection<GameBarItem> gameBarItem;

        Double w = 300;

        public IndexGameShowFrameViewModel()
        {
            this.gameBarItem = new System.Collections.ObjectModel.ObservableCollection<GameBarItem>();
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });

            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "1", Width = w });
            this.gameBarItem.Add(new GameBarItem() { Name = "2", Width = w });
        }

        
    }

    public class GameBarItem
    {
        public string Name;
        public Double Width;
    }
}
