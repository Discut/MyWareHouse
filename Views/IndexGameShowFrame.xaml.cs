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

    }
}
