using MyWareHouse.Models.Data;
using MyWareHouse.Models.FavoriteService;
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
        bool isGameItemMenuOpen = false;
        private ViewModels.IndexFrameViewModel indexFrameViewModel;
        public IndexFrame()
        {
            this.InitializeComponent();

            this.indexFrameViewModel = new ViewModels.IndexFrameViewModel();

            this.indexFrameViewModel.selectDfaultItem = () =>
            {
                if (this.navview.SelectedItem == null)
                    this.navview.SelectedItem = (this.navview.FooterMenuItemsSource as System.Collections.ObjectModel.ObservableCollection<GameBar>).First();
            };

            this.init();
        }

        private bool init()
        {
            this.DataContext = this.indexFrameViewModel;


            indexFrameViewModel.poinerAction = (Page page,object info, NavigationTransitionInfo transitionInfo) =>
            {
                Type type = page.GetType();
                // new EntranceNavigationTransitionInfo() 钻入
                this.ContentFrame.Navigate(type, info, transitionInfo);
            };

            

            return true;
        }

        private void leftBar_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void NavigationViewItem_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

            
            var flyout = FlyoutBase.GetAttachedFlyout((FrameworkElement)sender);
            var options = new FlyoutShowOptions()
            {
                // Position shows the flyout next to the pointer.
                // "Transient" ShowMode makes the flyout open in its collapsed state.
                Position = e.GetPosition((FrameworkElement)sender),
                ShowMode = FlyoutShowMode.Standard
            };
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)sender;



            if (navigationViewItem.Tag.ToString() == "Game")
            {

                IObservableVector<ICommandBarElement> secondaryCommands = GameBarContextMenu.SecondaryCommands;

                for (int index = 0; index < secondaryCommands.Count; index++){
                    AppBarButton commandBarElement = secondaryCommands[index] as AppBarButton;

                    if (commandBarElement.Tag as string == "MoveTo")
                    {
                        commandBarElement.Flyout = new MenuFlyout();

                        IList<Favorite> lists = FavoriteServiceFactory.Getter().GetAllFavorites();
                        foreach(Favorite favorite in lists)
                        {
                            MenuFlyoutItem item = new MenuFlyoutItem();
                            item.Text = favorite.Name;
                            item.Tag = favorite;
                            (commandBarElement.Flyout as MenuFlyout).Items.Add(item);
                        }
                    }
                }

                this.GameBarContextMenu.ShowAt(navigationViewItem, options);
                isGameItemMenuOpen = true;
            }
            else if(navigationViewItem.Tag.ToString() == "Favorite" && !isGameItemMenuOpen && navigationViewItem.Content != "未分类")
            {

                this.FavoriteBarContextMenu.ShowAt(navigationViewItem, options);
            }
        }

        private void MenuFlyout_Opening(object sender, object e)
        {
            //var se = (MenuFlyout)sender;
            //IList<MenuFlyoutItemBase> items = se.Items;
            //MenuFlyoutItemBase menuFlyoutItemBase = items[0];
            //items.Clear();
        }

        private void ReName(object sender, RoutedEventArgs e)
        {
            //indexFrameViewModel.ReName(sender, e);
        }

        private void MenuFlyoutItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
        }

        private void GameBarContextMenu_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            //IObservableVector<ICommandBarElement> secondaryCommands = this.GameBarContextMenu.SecondaryCommands;

            //for (int index = 0; index < secondaryCommands.Count; index++)
            //{
            //    AppBarButton commandBarElement = secondaryCommands[index] as AppBarButton;

            //    if (commandBarElement.Tag as string == "MoveTo")
            //    {
            //        commandBarElement.Flyout = null;
            //    }
            //}
            isGameItemMenuOpen = false;
        }
    }
}
