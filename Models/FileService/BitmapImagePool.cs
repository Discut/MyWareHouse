using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MyWareHouse.Models.FileService
{
    class BitmapImagePool : IImagePool<BitmapImage>
    {
        private BitmapImagePool() { }
        private static class Inner
        {
            public static IImagePool<BitmapImage> pool = new BitmapImagePool();
        }
        private Dictionary<string, BitmapImage> pool = new Dictionary<string, BitmapImage>();
        /// <summary>
        /// imag对象池实例
        /// </summary>
        public static IImagePool<BitmapImage> Instance()
        {
            
            return Inner.pool;
        }

        public BitmapImage this[string key] { 
            get
            {
                BitmapImage result = null;
                pool.TryGetValue(key, out result);
                return result;
            }
            set
            {
                if (pool.ContainsKey(key))
                    pool[key] = value;
                else
                    pool.Add(key, value);
            }
        }

        public void Init()
        {
            pool = new Dictionary<string, BitmapImage>();
        }
        public BitmapImage Delete(string key)
        {
            if (!pool.ContainsKey(key))
                return null;
            else
            {
                BitmapImage bitmapImage = pool[key];
                pool.Remove(key);
                return bitmapImage;
            }
        }
    }
}
