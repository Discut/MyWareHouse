using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarehouse.Models.Data
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Tag { get; set; } = "Index";
        public IconElement Icon { get; set; } = new SymbolIcon(Symbol.Library);
        public ObservableCollection<MenuItem> Children { get; set; }
    }
}
