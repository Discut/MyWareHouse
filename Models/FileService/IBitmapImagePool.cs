using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.FileService
{
    /// <summary>
    /// img对象池 初次实例化程序时进行读取并创建
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    interface IImagePool<T>
    {
        /// <summary>
        /// 初始化对象池
        /// </summary>
        void Init();
        ///// <summary>
        ///// 根据key 获取image对象
        ///// </summary>
        ///// <param name="key">字典中的key</param>
        ///// <returns>image对象</returns>
        ///// 
        //T GetIMG(string key);
        ///// <summary>
        ///// 添加img对象
        ///// </summary>
        ///// <param name="key">键</param>
        ///// <param name="img">image对象</param>
        //void AddIMG(string key, T img);
        /// <summary>
        /// 删除池中的对象
        /// </summary>
        /// <param name="key">对象key</param>
        /// <returns>已删除的对象</returns>
        T Delete(string key);
        /// <summary>
        /// 获取与设置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
         T this[string key]
        {
            get;
            set;
        }
    }
}
