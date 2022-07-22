using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseGetter
{
    public interface IDataBaseDataGetter
    {
        /// <summary>
        /// 获取所有的游戏
        /// </summary>
        /// <returns>返回以键值对为基础的列表</returns>
        IList<IDictionary<string, object>> GetAllGames();
        /// <summary>
        /// 获取某收藏夹下所有的游戏
        /// </summary>
        /// <param name="id">收藏夹id</param>
        /// <returns>返回以键值对为基础的列表</returns>
        IList<IDictionary<string, object>> GetGamesInFavorite(string id);
        /// <summary>
        /// 获取游戏的tags
        /// </summary>
        /// <param name="gameId">游戏id</param>
        /// <returns>装有tag的列表</returns>
        IList<string> GetGameTags(int gameId);
        /// <summary>
        /// 获取某一游戏下的链接
        /// </summary>
        /// <param name="gameId">游戏id</param>
        /// <returns>返回以键值对为基础的列表</returns>
        IList<IDictionary<string, object>> GetGameLinks(int gameId);
        /// <summary>
        /// 获取游玩记录
        /// </summary>
        /// <returns>游玩记录</returns>
        IList<IDictionary<string, object>> GetAllPlays();
        /// <summary>
        /// 获取此游戏的最近游戏时间
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        string GetPlayWith(string gameId);
        /// <summary>
        /// 获取游戏下的所有tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<IDictionary<string, object>> GetGameTags(string id);
    }
}
