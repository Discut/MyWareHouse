using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using DataAccessLibrary;
using System.Threading.Tasks;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace MyWareHouse.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ViewModels.MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            this.mainPageViewModel = new ViewModels.MainPageViewModel();
            this.DataContext = this.mainPageViewModel;   
        }

        private async Task init()
        {
            await Models.AppInitializer.Instance.Init();
            

            // 测试代码

            // 创建文件
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync("dark.png", CreationCollisionOption.OpenIfExists);

            
            //await FileIO.WriteTextAsync(file, "Write text to file.");
            //// 2  从文本读取文件
            //StorageFolder folder1 = Windows.Storage.ApplicationData.Current.LocalFolder;
            //StorageFile file1 = await folder.GetFileAsync("New Document.txt");
            //string text = await Windows.Storage.FileIO.ReadTextAsync(file1);

            //Windows.Storage.Streams.IBuffer asyncOperation = await FileIO.ReadBufferAsync(file1);




            ImageBrush img = new ImageBrush();

            BitmapImage bitmapImage = new BitmapImage();
            Windows.Storage.Streams.IRandomAccessStream randomAccessStream = await file.OpenAsync(FileAccessMode.Read);


            
            await bitmapImage.SetSourceAsync(randomAccessStream);
            bitmapImage.DecodePixelWidth = bitmapImage.PixelWidth;
            bitmapImage.DecodePixelHeight = bitmapImage.PixelHeight;


            img.ImageSource = bitmapImage;
            //ImageSource imageSource = new ImageSource();
            //imageSource.





        }

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await init();
            //System.Diagnostics.Process.Start(@"E:\Game\1room\Windows\1room.exe");
            this.IndexFrame.Navigate(typeof(Views.IndexFrame), null, new DrillInNavigationTransitionInfo());
        }
    }
}
