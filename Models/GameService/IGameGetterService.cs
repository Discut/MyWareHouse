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

        //IList<Data.G>
    }
}
