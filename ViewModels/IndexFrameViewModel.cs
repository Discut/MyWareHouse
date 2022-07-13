using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyWareHouse.ViewModels
{
    class IndexFrameViewModel
    {
        public Action<Frame> poinerAction;

        public IndexFrameViewModel()
        {

            FooterMenu = new ObservableCollection<Category>();
            FooterMenu.Add(new Category()
            {
                Name = "主页",
                Icon = new SymbolIcon(Symbol.Home),
                Children = null
            });
            FooterMenu.Add(new Category()
            {
                Name = "Plus New Item",
                Icon = new SymbolIcon(Symbol.Add),
                Children = null
            });
        }

        public ObservableCollection<Category> Categories = new ObservableCollection<Category>()
    {
        new Category(){
            Name = "Menu item 1",
            Children = new ObservableCollection<Category>() {
                new Category() {
                            Name  = "Menu item 3",
                            Children = null
                        }
            }
        },
        new Category(){
            Name = "Menu item 6",
            Children = null
        },
        new Category(){ Name = "Menu item 10" }
    };

        private ObservableCollection<Category> _footerMenu;

        public ObservableCollection<Category> FooterMenu
        {
            get { return _footerMenu; }
            set { _footerMenu = value; }
        }


        public void OnItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs e)
        {
            object invokedItem = e.InvokedItem;

            sender.Header = invokedItem;

            if (invokedItem as string == "Plus New Item")
            {
                this.Categories.Add(new Category()
                {
                    Name = "new item",
                    Icon = new SymbolIcon(Symbol.Page),
                    Children = null
                });
            } else if (invokedItem as string == "主页")
            {
                this.poinerAction?.Invoke(new Frame() { Content = new Views.IndexGameShowFrame() });
            }

        }
    }


    public class Category
    {
        public String Name { get; set; }
        public IconElement Icon = new SymbolIcon(Symbol.Library);
        public ObservableCollection<Category> Children { get; set; }
    }
}
