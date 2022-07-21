using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.GameService
{
    interface IGameModifyService
    {
        /// <summary>
        /// 更新游戏信息
        /// </summary>
        /// <param name="game">已修改的游戏对象</param>
        /// <returns>是否成功修改</returns>
        bool UpdataGame(Data.Game game);

        /// <summary>
        /// 新增游戏
        /// </summary>
        /// <param name="game">对象实例</param>
        /// <returns></returns>
        Data.Game InsertGame(Data.Game game);

        /// <summary>
        /// 删除游戏
        /// </summary>
        /// <param name="game"><对象实例/param>
        /// <returns>已删除的对象实例</returns>
        Data.Game DeleteGame(Data.Game game);
        /// <summary>
        /// 插入游玩记录
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="time"></param>
        void InsertPlay(string gameId, DateTime time);
    }
}
