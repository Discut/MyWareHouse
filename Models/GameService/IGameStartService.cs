using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.GameService
{
    interface IGameStartService
    {
        /// <summary>
        /// 游戏启动
        /// </summary>
        /// <param name="game">待启动的游戏对象</param>
        /// <returns>是否启动成功</returns>
        bool StartGame(Data.Game game);
        /// <summary>
        /// 游戏启动
        /// </summary>
        /// <param name="gameId">待启动的游戏id</param>
        /// <returns>是否启动成功</returns>
        bool StartGame(int gameId);
        /// <summary>
        /// 游戏启动
        /// </summary>
        /// <param name="gameName">待启动的游戏名</param>
        /// <returns>是否启动成功</returns>
        bool StartGame(string gameName);
        /// <summary>
        /// 打开游戏目录
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        bool OpenGameFolder(Data.Game game);
    }
}
