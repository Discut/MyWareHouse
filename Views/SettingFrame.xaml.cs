using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        public SettingFrame()
        {
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
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


            //img.ImageSource = bitmapImage;

            (sender as Windows.UI.Xaml.Controls.Image).Source = bitmapImage;
            //ImageSource imageSource = new ImageSource();
            //imageSource.

        }
    }
}
