using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data.Factory
{
    class FavoriteFactory
    {
        /// <summary>
        /// 创建收藏夹对象工厂方法
        /// </summary>
        /// <param name="info">收藏夹信息</param>
        /// <returns>收藏夹对象</returns>
        internal static Favorite GetFavorite(IDictionary<string, object> info)
        {
            Favorite favorite = new Favorite();
            favorite.Id = info.ContainsKey("id") ? info["id"].ToString() : null;
            favorite.Name = info.ContainsKey("name") ? info["name"].ToString() : "未分类";

            return favorite;
        }
    }
}
