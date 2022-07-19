using MyWareHouse.Models.Data;
using MyWareHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.System;
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
    public sealed partial class WarehouseIndexFrame : Page
    {
        

        private WarehouseIndexFrameViewModel viewModel;

        private Models.Data.GameBar _gameBar;

        public WarehouseIndexFrame()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.DataContext = viewModel = new WarehouseIndexFrameViewModel();


        }
        /**
         * <summary>
         * 游戏小图点击后转跳到游戏详情页
         * </summary>
         */
        private void GameBarItem_Click(object sender, ItemClickEventArgs e)
        {
            //gridViewTransform.PrepareConnectedAnimation("ForwardConnectedAnimation", item, "TransformeControl");

            // Get the collection item corresponding to the clicked item.
            if (gridViewTransform.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
                _gameBar = container.Content as Models.Data.GameBar;

                this.GotoGameInfoFrame(_gameBar, gridViewTransform);

            }
        }

        private void GameBarItem_AllGameBar_Click(object sender, ItemClickEventArgs e)
        {
            //gridViewTransform.PrepareConnectedAnimation("ForwardConnectedAnimation", item, "TransformeControl");

            // Get the collection item corresponding to the clicked item.
            if (AllGameGridView.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
                _gameBar = container.Content as Models.Data.GameBar;

                this.GotoGameInfoFrame(_gameBar, AllGameGridView);

            }
        }
        /**
         * <summary>
         * 页面转跳与动画实现
         * </summary>
         */
        private void GotoGameInfoFrame(object control, GridView gridView)
        {

            if (control != null)
            {
                // Prepare the connected animation.
                // Notice that the stored item is passed in, as well as the name of the connected element. 
                // The animation will actually start on the Detailed info page.
                var animation = gridView.PrepareConnectedAnimation("ForwardConnectedAnimation", control, "TransformeControl");
            }

            // Navigate to the DetailedInfoPage.
            // Note that we suppress the default animation. 
            Frame.Navigate(typeof(Views.GameInfoFrame), control, new DrillInNavigationTransitionInfo());
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {

            var users = await Windows.System.User.FindAllAsync();
            if (users.Count > 0)
            {
                var user1s = await User.FindAllAsync(UserType.LocalUser);
                var user = (string)await users.FirstOrDefault().GetPropertyAsync(KnownUserProperties.AccountName);
                var last = (string)await users.FirstOrDefault().GetPropertyAsync(KnownUserProperties.LastName);
                var first = (string)await users.FirstOrDefault().GetPropertyAsync(KnownUserProperties.FirstName);
                string displayName = (string)await users.FirstOrDefault().GetPropertyAsync("Gamertag");

                var domain = "";
                var host = "";

                if (string.IsNullOrEmpty(user))
                {
                    var domainWithUser = (string)await users.FirstOrDefault().GetPropertyAsync(KnownUserProperties.DomainName);
                    domain = domainWithUser.Split('\\')[0];
                    user = domainWithUser.Split('\\')[1];
                }
                viewModel.AcountName = first + last;

                DateTime now = DateTime.Now;
                 
                int hour = now.Hour;

                if (hour > 6 && hour <= 8)
                    viewModel.Hello = "早上好";
                else if (hour > 8 && hour < 10)
                    viewModel.Hello = "上午好";
                else if (hour >= 11 && hour <= 13)
                    viewModel.Hello = "中午好";
                else if (hour > 13 && hour < 18)
                    viewModel.Hello = "下午好";
                else
                    viewModel.Hello = "晚上好";
                viewModel.WeekTitle = now.DayOfWeek.ToString();

            }
        }
    }
}
