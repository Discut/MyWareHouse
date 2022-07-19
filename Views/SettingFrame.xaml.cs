using MyWareHouse.Models.Data.Theme;
using MyWareHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
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
    public sealed partial class SettingFrame : Page
    {
        private SettingFrameViewModel ViewModel;
        public SettingFrame()
        {
            this.InitializeComponent();
            ViewModel = new SettingFrameViewModel();
            this.DataContext = ViewModel;
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           (this.DataContext as SettingFrameViewModel).Theme.Theme = new LightTheme();
            (this.DataContext as SettingFrameViewModel).Text = "asdas";
        }
    }
}
