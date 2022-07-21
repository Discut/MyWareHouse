using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    public interface IGameSetter
    {
        /// <summary>
        /// 更新游戏信息
        /// </summary>
        /// <param name="data">等待更新的键值对数据</param>
        /// <returns>是否更新成功</returns>
        bool UpdateGame(IDictionary<string, object> data);
        /// <summary>
        /// 删除游戏信息
        /// </summary>
        /// <param name="id">游戏id</param>
        /// <returns>是否删除</returns>
        bool DeleteGame(int id);
        /// <summary>
        /// 插入游戏信息
        /// </summary>
        /// <param name="gameInfo">游戏信息键值对</param>
        /// <returns>已插入的带id信息</returns>
        IDictionary<string, object> InsertGame(IDictionary<string, object> gameInfo);
        /// <summary>
        /// 插入游玩时间
        /// </summary>
        /// <param name="id">游戏id</param>
        /// <param name="dateTime">游玩时间</param>
        void InsertGamePlay(string id, DateTime dateTime);
    }
}
