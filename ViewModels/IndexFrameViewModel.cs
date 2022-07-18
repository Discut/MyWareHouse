using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

using MyWareHouse.Models.Data;
using Windows.UI.Xaml;
using MyWareHouse.Models.GameService;
using MyWareHouse.Models.FavoriteService;
using MyWareHouse.Models.GameService.Implement;

namespace MyWareHouse.ViewModels
{
    class IndexFrameViewModel
    {
        private bool isChangeToIndex = false;
        public Action<Page, object, Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo> poinerAction;

        public Action selectDfaultItem;

        public IndexFrameViewModel()
        {
        }

        public ObservableCollection<GameBar> Categories = new ObservableCollection<GameBar>();

        private ObservableCollection<GameBar> _footerMenu = new ObservableCollection<GameBar>()
        {
            new GameBar(null)
            {
                Title = "主页",
                Tag = "Index",
                Icon = new SymbolIcon(Symbol.Home)
            },
            new GameBar(null)
            {
                Title = "添加新游戏",
                Icon = new SymbolIcon(Symbol.Add),
                Tag = "AddGame",
                Children = null
            },
            new GameBar(null)
            {
                Title = "新建收藏夹",
                Tag = "AddFavorite",
                Icon = new SymbolIcon(Symbol.Add),
                Children = null
            }
        };

        public ObservableCollection<GameBar> FooterMenu
        {
            get { return _footerMenu; }
            set { _footerMenu = value; }
        }


        public void OnItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs e)
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem ItemContainer = (Microsoft.UI.Xaml.Controls.NavigationViewItem)e.InvokedItemContainer;
            if (ItemContainer.Tag is GameBar gameBar)
            {
                if (gameBar.Tag as String == "AddGame")
                {
                    AddNewGame();
                }
                else if (gameBar.Tag as String == "AddFavorite")
                {
                    AddFavorite();
                }
                else
                    IntoFrame(sender, gameBar.Tag);
            }
            else if (e.IsSettingsInvoked)
            {
                IntoFrame(sender, "Setting");
            }
            //sender.Header = invokedItem;

            

        }
        public void leftBar_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (!isChangeToIndex)
            {
                GameBar p = (GameBar)args.SelectedItem;
                IntoFrame(sender, p.Tag);
                isChangeToIndex = true;
            }
            //if (args.IsSettingsSelected)
            //{
            //    this.ContentFrame.Navigate(typeof(Views.SettingFrame), null, new DrillInNavigationTransitionInfo());
            //}
        }

        private void FastIntoFrame(string tag, object arg)
        {
            switch (tag as string)
            {
                case "Game":
                    this.poinerAction?.Invoke(new Views.GameInfoFrame(), arg, new DrillInNavigationTransitionInfo());
                    break;
                case "Index":
                    this.poinerAction?.Invoke(new Views.WarehouseIndexFrame(), null, new EntranceNavigationTransitionInfo());
                    break;
                case "Favorite":
                    this.poinerAction?.Invoke(new Views.IndexGameShowFrame(), arg, new EntranceNavigationTransitionInfo());
                    break;
                case "Setting":
                    this.poinerAction?.Invoke(new Views.SettingFrame(), null, new EntranceNavigationTransitionInfo());
                    break;
            }
        }
        private void IntoFrame(Microsoft.UI.Xaml.Controls.NavigationView sender, object tag)
        {
            object selectedItem = null;
            if (sender != null)
                selectedItem = sender.SelectedItem;
            FastIntoFrame(tag as string, selectedItem);
            
        }

        private async void AddNewGame()
        {
            //1.创建和自定义 FileOpenPicker
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;

            picker.FileTypeFilter.Add(".exe");


            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                string name = file.DisplayName;
                string appPath = file.Path.Replace("\\", "/");

                //Windows.System.Launcher.LaunchUriAsync(new Uri("MyWarehouse://" + appPath));

                Game game = GameFactory.GetGame(name,appPath);

                Game game1 = GameServiceFactory.GetGameModifyService().InsertGame(game);
                Update();
            }
            //else
            //{
            //    //this.textBlock.Text = "Operation cancelled.";
            //}
        }

        private async void AddFavorite()
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "请输入收藏夹名称",
                PrimaryButtonText = "取消",
                SecondaryButtonText = "确定",
                FullSizeDesired = false,
                DefaultButton = ContentDialogButton.Secondary
            };
            StackPanel sp = new StackPanel();
            TextBox favoriteTitle = new TextBox();
            favoriteTitle.TextWrapping = TextWrapping.NoWrap;
            favoriteTitle.PlaceholderText = "收藏夹名称";
            sp.Children.Add(favoriteTitle);
            dialog.Content = sp; 

            dialog.SecondaryButtonClick += (_s, _e) => {
                string title = favoriteTitle.Text;

                var service = FavoriteServiceFactory.Setter();

                service.AddFavorite(title);

                Update();
            };
            await dialog.ShowAsync();
        }

        internal void ReName(GameBar target, string newName)
        {
            switch (target.Tag)
            {
                case "Game":
                    Game game = target.Game;
                    game.Name = newName;
                    target.Title = newName;
                    //target.Title = newName;
                    GameServiceFactory.GetGameModifyService().UpdataGame(game);
                    Update();
                    break;
                case "Favorite":
                    FavoriteServiceFactory.Setter().Rename(target.Id, newName);
                    for (int i = 0; i < Categories.Count; i++)
                    {
                        if (Categories[i].Id == target.Id)
                        {
                            Categories[i].Title = newName;
                        }
                    }
                    Update();
                    break;
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void Update()
        {
            this.Categories.Clear();
            IGameGetterService service = GameServiceFactory.GetGameGetterService();
            IList<GameBar> lists = service.GetGameBarList();
            foreach (GameBar bar in lists)
            {
                this.Categories.Add(bar);
            }
            // 使用默认选择
            selectDfaultItem?.Invoke();
        }
        ///// <summary>
        ///// 重名名游戏
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public void ReName(object sender, RoutedEventArgs e)
        //{

        //}

        public void Page_Loading(FrameworkElement sender, object args)
        {
            Update();
            selectDfaultItem?.Invoke();
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
