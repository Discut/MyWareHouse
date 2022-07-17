using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.FavoriteService
{
    /// <summary>
    /// 收藏夹获取器
    /// </summary>
    interface IFavoriteGetter<T>
    {
        /// <summary>
        /// 获取所有的收藏夹
        /// </summary>
        /// <returns>收藏夹列表</returns>
        IList<T> GetAllFavorites();
    }
}
