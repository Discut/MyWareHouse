using MyWareHouse.Models.Data;
using MyWareHouse.Models.FavoriteService;
using MyWareHouse.Models.ThemeService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
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
        /// <summary>
        /// 右键菜单栏选中的目标
        /// </summary>
        private GameBar target;
        /// <summary>
        /// 数据绑定
        /// </summary>
        private ViewModels.IndexFrameViewModel indexFrameViewModel;

        internal ViewModels.IndexFrameViewModel ViewModels
        {
            get => indexFrameViewModel;
            set => indexFrameViewModel = value;
        }
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
            // 获取点击菜单项
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)sender;
            // 获取点击菜单项的tag
            string tag = (navigationViewItem.Tag as GameBar).Tag.ToString();


            if (tag == "Game")
            {
                this.target = navigationViewItem.Tag as GameBar;

                IObservableVector<ICommandBarElement> secondaryCommands = GameBarContextMenu.SecondaryCommands;

                for (int index = 0; index < secondaryCommands.Count; index++){
                    AppBarButton commandBarElement = secondaryCommands[index] as AppBarButton;

                    if (commandBarElement.Tag as string == "MoveTo")
                    {
                        commandBarElement.Flyout = new MenuFlyout();

                        IList<Favorite> lists = FavoriteServiceFactory.Getter().GetAllFavorites();
                        foreach(Favorite favorite in lists)
                        {
                            // 创建移动到收藏夹菜单按钮
                            MenuFlyoutItem item = new MenuFlyoutItem();
                            item.Text = favorite.Name;
                            item.Tag = favorite; 
                            // 绑定事件
                            item.Click += MoveToFavorite;
                            (commandBarElement.Flyout as MenuFlyout).Items.Add(item);
                        }
                    }
                }

                this.GameBarContextMenu.ShowAt(navigationViewItem, options);
                isGameItemMenuOpen = true;
            }
            else if(tag == "Favorite" && !isGameItemMenuOpen && navigationViewItem.Content != "未分类")
            {
                this.target = navigationViewItem.Tag as GameBar;

                this.FavoriteBarContextMenu.ShowAt(navigationViewItem, options);
            }
        }


        private void GameBarContextMenu_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        { 
            isGameItemMenuOpen = false;
        }

        private async void ReName(object sender, RoutedEventArgs e)
        {

            ContentDialog dialog = new ContentDialog()
            {
                Title = "请输入新的名称",
                PrimaryButtonText = "取消",
                SecondaryButtonText = "确定",
                FullSizeDesired = false,
                DefaultButton = ContentDialogButton.Secondary
            };
            StackPanel sp = new StackPanel();
            TextBox titleInput = new TextBox();
            titleInput.TextWrapping = TextWrapping.NoWrap;
            titleInput.PlaceholderText = "新名称";
            sp.Children.Add(titleInput);
            dialog.Content = sp;

            dialog.SecondaryButtonClick += (_s, _e) => {
                string title = titleInput.Text;

                indexFrameViewModel.ReName(this.target, title);


            };
            await dialog.ShowAsync();
        }
        private void MoveToFavorite(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem container)
                indexFrameViewModel.MoveToFavorite(container.Tag, target);
        }

        private void DeleteGame(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarButton container)
            {
                indexFrameViewModel.DeleteGame(target);
            }
        }

        private void DeleteFavorite(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarButton container)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("id", target.Id);
                dic.Add("name", target.Title);
                Favorite favorite = Models.Data.Factory.FavoriteFactory.GetFavorite(dic);
                indexFrameViewModel.DeleteFavorite(favorite);
            }
        }
        private void MoveOutFavorite(object sender, RoutedEventArgs e)
        {
            indexFrameViewModel.MoveOutFavorite(target);
        }

        /// <summary>
        /// 当菜单Item加载时调用
        /// 
        /// 由于使用x:bind绑定Item的Icon会导致错误，只能在菜单加载时绑定Icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationViewItem_Loading(FrameworkElement sender, object args)
        {
            if (sender is Microsoft.UI.Xaml.Controls.NavigationViewItem item)
            {
                GameBar tag = item.Tag as GameBar;
                item.Icon = tag.Icon;
            }
        }
    }
}
