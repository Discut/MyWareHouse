using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.ApplicationModel;
using Windows.Storage;
using MyWareHouse.Models.Data;
using MyWareHouse.Models.FileService;
using MyWareHouse.Models.GameService;
using MyWareHouse.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MyWareHouse.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GameInfoFrame : Page
    {
        public string Title { get; set; }

        private string appPath;

        private Game game;

        private GameInfoFrameViewModel _viewModel;

        public GameInfoFrameViewModel ViewModel { get=>_viewModel; set=>_viewModel=value; }

        public GameInfoFrame()
        {
            this.InitializeComponent();
            // 开放数据源
            this.ViewModel = new GameInfoFrameViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void PrepareConnectedAnimation(ConnectedAnimationConfiguration config)
        {
            var anim = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", SourceElement1);

            if (config != null && ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                anim.Configuration = config;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GameBar gameBar = e.Parameter as GameBar;
            if (gameBar != null)
            {
                this.Title = gameBar.Title;
                this.appPath = gameBar.Game.ApplicationPath;
                game = gameBar.Game;
            }

            var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
            {
                anim.TryStart(SourceElement1);
            }

            if (e.Parameter is Models.Data.GameBar)
            {

            }
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            IGameStartService service = GameStartByLauncher.Instance;
            service.StartGame(game);

            //Windows.System.Launcher.LaunchUriAsync(new Uri("MyWarehouse://" + appPath));

            //try
            //{
            //    Process.Start(@"explorer.exe");

            //}
            //catch (Exception EX)
            //{
            //    Console.WriteLine(EX.ToString());
            //}

            //ApplicationData.Current.LocalSettings.Values["app"] = "1";

            //if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            //{
            //    try
            //    {
            //        await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            //    }

            //    catch (Exception Ex)
            //    {
            //        Debug.WriteLine(Ex.ToString());
            //    }
            //}

            //Process.Start("Assets/Luncher.exe", "1 2 3");
            //Windows.ApplicationModel
            //await Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("rebooter");
            //await Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("123123");
            //await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppWithArgumentsAsync();




            //System.Diagnostics.Process.Start(@"E:\\工具\Cheat Engine 7.2\Cheat Engine.exe");

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(@"E:\Game\1room\Windows\1room.exe");
            //info.WorkingDirectory = @"E:\Game\1room\Windows";
            //process.StartInfo = info;
            //try
            //{
            //    process.Start();

            //}
            //catch (System.ComponentModel.Win32Exception w)
            //{
            //    Console.WriteLine(w.Message);
            //    Console.WriteLine(w.ErrorCode.ToString());
            //    Console.WriteLine(w.NativeErrorCode.ToString());
            //    Console.WriteLine(w.StackTrace);
            //    Console.WriteLine(w.Source);
            //}

            //System.Diagnostics.Process.Start("cmd.exe");

            //Process p = new Process();
            ////设置要启动的应用程序
            //p.StartInfo.FileName = "cmd.exe";
            ////是否使用操作系统shell启动
            //p.StartInfo.UseShellExecute = false;
            //// 接受来自调用程序的输入信息
            //p.StartInfo.RedirectStandardInput = true;
            ////输出信息
            //p.StartInfo.RedirectStandardOutput = true;
            //// 输出错误
            //p.StartInfo.RedirectStandardError = true;
            ////不显示程序窗口
            //p.StartInfo.CreateNoWindow = false;
            ////启动程序
            //p.Start();

            ////向cmd窗口发送输入信息
            //p.StandardInput.WriteLine(@"start E:\工具\右键菜单管理.NET.4.0.exe" + "&exit");
            ////等待程序执行完退出进程
            //p.WaitForExit();
            //p.Close();





            //p.StandardInput.AutoFlush = true;


            ////获取输出信息
            //string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            //p.WaitForExit();
            //p.Close();

            //info.UseShellExecute = false;
            //process.StartInfo = info;
            //process.Start();



            //if (!File.Exists(@"E:\工具"))
            //{
            //    throw new ArgumentException("启动软件路径不存在" + @"E:\工具\Macast-v0.5(投屏接收器).exe");
            //}



            //Process.Start(@"E:\工具\Macast-v0.5(投屏接收器).exe");
            //object p = MessageBox.Show(String.Format("外部程序 {0} 启动完成！", this.appName), this.Text,
            //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
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
                string name = file.Name;
                string appPath = file.Path.Replace("\\","/");

            }
            else
            {
                //this.textBlock.Text = "Operation cancelled.";
            }
        }

        private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var flyout = FlyoutBase.GetAttachedFlyout((FrameworkElement)sender);
            var options = new FlyoutShowOptions()
            {
                // Position shows the flyout next to the pointer.
                // "Transient" ShowMode makes the flyout open in its collapsed state.
                Position = e.GetPosition((FrameworkElement)sender),
                ShowMode = FlyoutShowMode.Standard
            };
            //flyout?.ShowAt((FrameworkElement)sender, options);
            this.selectMenu.ShowAt(sender as Grid, options);
        }

        private async void SetHeadImageAsync(object sender, RoutedEventArgs e)
        {
            //1.创建和自定义 FileOpenPicker
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;

            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");


            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                string name = file.DisplayName;
                string appPath = file.Path.Replace("\\", "/");

                //Windows.System.Launcher.LaunchUriAsync(new Uri("MyWarehouse://" + appPath));

                await ImageFileService.Instance().InsertImage(this.game.Id, file);

                Update();
            }

        }
        private async void ClearHeadImageAsync(object sender, RoutedEventArgs e)
        {
            await ImageFileService.Instance().ClearImage(this.game.Id);
            Update();
        }
        private async void SetBackgroudImageAsync(object sender, RoutedEventArgs e)
        {
            //1.创建和自定义 FileOpenPicker
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;

            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");


            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                string name = file.DisplayName;
                string appPath = file.Path.Replace("\\", "/");

                //Windows.System.Launcher.LaunchUriAsync(new Uri("MyWarehouse://" + appPath));

                await ImageFileService.Instance().InsertImage(this.game.Id+"_bgi", file);

                Update();
            }
        }
        private async void ClearBackgroudImageAsync(object sender, RoutedEventArgs e)
        {
            await ImageFileService.Instance().ClearImage(this.game.Id+"_bgi");
            Update();
        }
        public void Update()
        {
            // 获取头图
            Windows.UI.Xaml.Media.Imaging.BitmapImage headImage = ImageFileService.Instance().TryGetImage(game.Id);
            HeadImage.Source = headImage;
            // 获取背景图
            Windows.UI.Xaml.Media.Imaging.BitmapImage bgiImage = ImageFileService.Instance().TryGetImage(game.Id + "_bgi");
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = bgiImage;
            BackgroundBrush.ImageSource = bgiImage;

        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            Update();
        }

        public Visibility IsShowSetHeadImage
        {
            get
            {
                if (HeadImage.Source == null)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }
        public Visibility IsShowClearHeadImage
        {
            get
            {
                return IsShowSetHeadImage == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        public Visibility IsShowSetBackgroundImage
        {
            get
            {
                if (BackgroundBrush.ImageSource == null)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }
        public Visibility IsShowClearBackgroundImage
        {
            get
            {
                return IsShowSetBackgroundImage == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
