using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MyWareHouse.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class IndexFrame : Page
    {
        private ViewModels.IndexFrameViewModel indexFrameViewModel;
        public IndexFrame()
        {
            this.InitializeComponent();

            this.indexFrameViewModel = new ViewModels.IndexFrameViewModel();


            this.init();
        }

        private bool init()
        {
            this.DataContext = this.indexFrameViewModel;


            indexFrameViewModel.poinerAction = (Frame frame) =>
            {
                this.ContentFrame.Navigate(typeof(Views.IndexGameShowFrame), null, new EntranceNavigationTransitionInfo());
            };

            

            return true;
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void leftBar_Loaded(object sender, RoutedEventArgs e)
        {
            this.navview.SelectedItem = (this.navview.MenuItemsSource as System.Collections.ObjectModel.ObservableCollection<ViewModels.Category>).First();
        }

        private void leftBar_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                this.ContentFrame.Navigate(typeof(Views.SettingFrame), null, new DrillInNavigationTransitionInfo());
            }
            else
            {

                switch (((ViewModels.Category)args.SelectedItem).Tag)
                {
                    case "Index":
                        this.ContentFrame.Navigate(typeof(Views.WarehouseIndexFrame), null);
                        break;
                    default:
                        this.ContentFrame.Navigate(typeof(Views.IndexGameShowFrame), null);
                        break;
                }

            }
        }
    }
}
