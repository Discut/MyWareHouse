using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.GameService
{
    interface IGameGetterService
    {
        /// <summary>
        /// 获取游戏侧边栏列表
        /// </summary>
        /// <returns>游戏侧边栏列表</returns>
        IList<Data.GameBar> GetGameBarList();
        /// <summary>
        /// 获取收藏夹下的所有游戏
        /// </summary>
        /// <param name="favorite">收藏夹对象</param>
        /// <returns>游戏集合</returns>
        IList<Data.Game> GetAllGamesBy(Data.Favorite favorite);
        /// <summary>
        /// 获取所有游戏的游玩记录
        /// </summary>
        /// <returns></returns>
        IList<IDictionary<string, object>> GetAllPlays();
        /// <summary>
        /// 获取某一游戏的最近游玩时间
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        string GetGamePlay(Data.Game game);
    }
}
