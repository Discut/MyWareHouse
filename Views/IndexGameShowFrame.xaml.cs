using MyWareHouse.Models.Data;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MyWareHouse.Views
{


    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class IndexGameShowFrame : Page
    {
        private Models.Data.GameBar _gameBar;

        public double _width = 400;

        public Thickness thickness = new Thickness(20,20,20,20);

        private ViewModels.IndexGameShowFrameViewModel indexGameShowFrameViewModel;
        public IndexGameShowFrame()
        {
            this.InitializeComponent();

            this.indexGameShowFrameViewModel = new ViewModels.IndexGameShowFrameViewModel();

            this.DataContext = indexGameShowFrameViewModel;

        }
        public void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.GameGridView.ItemContainerStyle.
            //this.style.SetValue(this.setter.Property, new Thickness(0,0,0,0));

            //this.thickness = new Thickness(0,0,0,0);
            Size newSize = e.NewSize;

            this._width = newSize.Width - (300 * 2);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GameBar gameBar = e.Parameter as GameBar;
            if (gameBar != null)
            {
                indexGameShowFrameViewModel.Title = gameBar.Title;
                indexGameShowFrameViewModel.init(gameBar);

            }

        }

        private void GameGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Get the collection item corresponding to the clicked item.
            if (GameGridView.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
                _gameBar = container.Content as Models.Data.GameBar;

                this.GotoGameInfoFrame(_gameBar, GameGridView);

            }
        }

        /// <summary>
        /// 页面转跳动画实现
        /// </summary>
        /// <param name="control"></param>
        /// <param name="gridView"></param>
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
    }
}
