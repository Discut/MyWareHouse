using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
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
        private ViewModels.GameBarItem _gameBar;

        public List<ViewModels.GameBarItem> gameBarItem = new List<ViewModels.GameBarItem>() {
        new ViewModels.GameBarItem()
        {
            Name="1232"
        },
        new ViewModels.GameBarItem()
        {
            Name="1232"
        },
        new ViewModels.GameBarItem(),
        new ViewModels.GameBarItem(),
        new ViewModels.GameBarItem(),
        new ViewModels.GameBarItem(),
        new ViewModels.GameBarItem(),
        new ViewModels.GameBarItem(),
        new ViewModels.GameBarItem(),
        };


        public WarehouseIndexFrame()
        {
            this.InitializeComponent();
        }


        public void PrepareAnimationWithItem(ViewModels.GameBarItem item)
        {

            
            //var anim = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BackwardConnectedAnimation", DestinationElement);

            //if (config != null && ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            //{
            //    anim.Configuration = config;
            //}
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackwardConnectedAnimation");
            if (anim != null)
            {
                //AddContentPanelAnimations();
                //anim.TryStart(DestinationElement);
            }
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PrepareAnimationWithItem((ViewModels.GameBarItem)e.AddedItems[0]);


            
        }

        private void gridViewTransform_ItemClick(object sender, ItemClickEventArgs e)
        {
            //gridViewTransform.PrepareConnectedAnimation("ForwardConnectedAnimation", item, "TransformeControl");

            // Get the collection item corresponding to the clicked item.
            if (gridViewTransform.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
                _gameBar = container.Content as ViewModels.GameBarItem;

                // Prepare the connected animation.
                // Notice that the stored item is passed in, as well as the name of the connected element. 
                // The animation will actually start on the Detailed info page.
                var animation = gridViewTransform.PrepareConnectedAnimation("ForwardConnectedAnimation", _gameBar, "TransformeControl");

            }

            // Navigate to the DetailedInfoPage.
            // Note that we suppress the default animation. 
            Frame.Navigate(typeof(Views.GameInfoFrame), _gameBar, new SuppressNavigationTransitionInfo());
        }
    }
}
