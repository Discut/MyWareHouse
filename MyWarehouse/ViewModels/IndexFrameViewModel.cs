using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarehouse.ViewModels
{
    public class IndexFrameViewModel
    {
        public ObservableCollection<Models.Data.MenuItem> MenuItems { get; set; }
        public string text { get; set; } = "This a binding data.";
        public IndexFrameViewModel()
        {
            MenuItems = new ObservableCollection<Models.Data.MenuItem>()
            {
                new Models.Data.MenuItem()
                {
                    Title = "1231",
                    Children = new ObservableCollection<Models.Data.MenuItem>()
                    {
                        new Models.Data.MenuItem()
                        {
                            Title = "DNF DULL"
                        }

                    }
                    
                },
                new Models.Data.MenuItem()
                {
                    Title = "1231"
                }
            };
        }
    }
}
