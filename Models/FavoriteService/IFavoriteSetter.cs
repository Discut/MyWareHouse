using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.FavoriteService
{
    interface IFavoriteSetter<T>
    {
        /// <summary>
        /// 添加新的收藏夹
        /// </summary>
        /// <param name="title">收藏夹名称</param>
        /// <returns>返回插入的收藏夹</returns>
        T AddFavorite(string title = "未分类");
    }
}
