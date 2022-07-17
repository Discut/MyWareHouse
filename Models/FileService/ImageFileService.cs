using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace MyWareHouse.Models.FileService
{
    class ImageFileService : IImageFileService<BitmapImage>
    {
        private IImagePool<BitmapImage> pool;

        private static class Inner
        {
            public static IImageFileService<BitmapImage> service = new ImageFileService();
        }
        /// <summary>
        /// 单例模式的对象实例
        /// </summary>
        public static IImageFileService<BitmapImage> Instance()
        {
            return Inner.service;
        }
        private ImageFileService() 
        {
            pool = BitmapImagePool.Instance();
        }
        public BitmapImage TryGetImage(string key)
        {
            if (null != key)
                return pool[key];
            return null;
        }

        public async Task InitAsync()
        {
            // 获取本地存储文件夹
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            // 判断是否有iamge文件夹
            StorageFolder imageFolder = await folder.CreateFolderAsync("image", CreationCollisionOption.OpenIfExists);
            // 遍历此文件夹下的文件
            IReadOnlyList<IStorageItem> readOnlyLists = await imageFolder.GetItemsAsync();
            foreach(StorageFile file in readOnlyLists)
            {
                // 转化为图像 并存入图像池
                BitmapImage bitmapImage = new BitmapImage();
                Windows.Storage.Streams.IRandomAccessStream randomAccessStream = await file.OpenAsync(FileAccessMode.Read);
                await bitmapImage.SetSourceAsync(randomAccessStream);
                bitmapImage.DecodePixelWidth = bitmapImage.PixelWidth;
                bitmapImage.DecodePixelHeight = bitmapImage.PixelHeight;
                pool[file.DisplayName] = bitmapImage;
            }
            
        }


        /// <summary>
        /// 流转化为byte数组
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static async Task<byte[]> ConvertIRandomAccessStreamByte(IRandomAccessStream stream)

        {

            DataReader read = new DataReader(stream.GetInputStreamAt(0));

            await read.LoadAsync((uint)stream.Size);

            byte[] temp = new byte[stream.Size];

            read.ReadBytes(temp);

            return temp;

        }


        public async Task InsertImage(string key, StorageFile imageFile)
        {
            if (null == key || null == imageFile)
                return;
            string name = imageFile.Name;
            string type = imageFile.FileType;

            IRandomAccessStream asyncOperation = await imageFile.OpenAsync(FileAccessMode.Read);

            BitmapImage image = new BitmapImage();
            image.SetSource(asyncOperation);
            pool[key] = image;

            // 写入本地
            // 获取本地存储文件夹
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            // 判断是否有iamge文件夹
            StorageFolder imageFolder = await folder.CreateFolderAsync("image", CreationCollisionOption.OpenIfExists);






            StorageFile storageFile = await imageFolder.CreateFileAsync(key + type, CreationCollisionOption.FailIfExists);

            await FileIO.WriteBytesAsync(storageFile, await ConvertIRandomAccessStreamByte(asyncOperation));




            //using (var memoryStream = new System.IO.MemoryStream())
            //{
            //    memoryStream.Capacity = (int)asyncOperation.Size;
            //    var ibuffer = memoryStream.GetWindowsRuntimeBuffer();
            //    IBuffer buffer = await asyncOperation.ReadAsync(ibuffer, (uint)asyncOperation.Size, InputStreamOptions.None);
            //    try
            //    {
            //        StorageFile storageFile = await imageFolder.CreateFileAsync(key + type, CreationCollisionOption.FailIfExists);
            //        StorageFile wait = await imageFolder.GetFileAsync(key + type);
            //        using (StorageStreamTransaction transaction = await wait.OpenTransactedWriteAsync(StorageOpenOptions.AllowReadersAndWriters))
            //        {
            //            using (DataWriter dataWriter = new DataWriter(transaction.Stream))
            //            {
            //                dataWriter.WriteBuffer(buffer);
            //                transaction.Stream.Size = await dataWriter.StoreAsync();
            //                await transaction.CommitAsync();
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}

            

        }

        public Task UpdateImage(string key, StorageFile image)
        {
            throw new NotImplementedException();
        }

        public async Task ClearImage(string key)
        {
            // 获取本地存储文件夹
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            // 判断是否有iamge文件夹
            StorageFolder imageFolder = await folder.CreateFolderAsync("image", CreationCollisionOption.OpenIfExists);

            IReadOnlyList<StorageFile> files = await imageFolder.GetFilesAsync();
            foreach(StorageFile file in files)
            {
                if (file.DisplayName == key)
                {
                    await file.DeleteAsync();
                    pool.Delete(key);
                    return;
                }
            }
            
        }
    }
}
