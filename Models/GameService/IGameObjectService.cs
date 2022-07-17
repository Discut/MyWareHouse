using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.GameService
{
    interface IGameObjectService<T>
    {
        /// <summary>
        /// 获取以收藏夹分类的map
        /// </summary>
        /// <returns>map</returns>
        IDictionary<string,IList<T>> GetDictionaryByFavorite();
        /// <summary>
        /// 获取游戏对象
        /// </summary>
        /// <param name="id">游戏id</param>
        /// <returns>游戏对象</returns>
        T GetGame(int id);
        /// <summary>
        /// 获取游戏对象
        /// </summary>
        /// <param name="gameName">游戏名</param>
        /// <returns>游戏对象</returns>
        T GetGame(string gameName);

        /// <summary>
        /// 获取所有的游戏
        /// </summary>
        /// <returns></returns>
        IList<T> GetAllGames();
        /// <summary>
        /// 获取最近打开游戏
        /// </summary>
        /// <returns>最近游戏列表</returns>
        IList<T> GetLastGames();
        /// <summary>
        /// 根据收藏夹获取游戏对象列表
        /// </summary>
        /// <param name="id">收藏夹id</param>
        /// <returns>游戏对象列表</returns>
        IList<T> GetFavoriteGames(string id);


    }
}
