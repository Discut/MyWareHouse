using MyWareHouse.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyWareHouse.Models.FileService
{
    interface IImageFileService<T>
    {
        Task InitAsync();

        T TryGetImage(string key);
        Task UpdateImage(string key, StorageFile image);
        /// <summary>
        /// 插入并保存图像
        /// </summary>
        /// <param name="key">图像id 尽量保证唯一性</param>
        /// <param name="image">图像文件</param>
        Task InsertImage(string key, StorageFile image);

        Task ClearImage(string key);
    }
}
