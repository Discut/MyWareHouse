using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseGetter
{
    public interface IFavoriteGetter
    {
        /// <summary>
        /// 获取所有的收藏夹
        /// </summary>
        /// <returns>返回以键值对为基础的列表</returns>
        IList<IDictionary<string, object>> GetAllFavorites();
    }
}
