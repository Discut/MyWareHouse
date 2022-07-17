using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    public interface IFavoriteSetter
    {
        /// <summary>
        /// 更新收藏夹信息
        /// </summary>
        /// <param name="data">等待更新的键值对数据</param>
        /// <returns>是否更新成功</returns>
        bool UpdateFavorite(IDictionary<string, object> data);
        /// <summary>
        /// 删除收藏夹信息
        /// </summary>
        /// <param name="id">收藏夹id</param>
        /// <returns>是否删除</returns>
        bool DeleteFavorite(int id);
        /// <summary>
        /// 插入收藏夹信息
        /// </summary>
        /// <param name="favoriteInfo">收藏夹信息键值对</param>
        /// <returns>已插入的带id信息</returns>
        IDictionary<string, object> InsertFavorite(IDictionary<string, object> favoriteInfo);
    }
}
