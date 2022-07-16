using DataAccessLibrary.DataBaseGetter;
using DataAccessLibrary.DataBaseSetter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDataBaseFactory
    {
        /// <summary>
        /// 初始化数据库工厂
        /// </summary>
        void Init();
        /// <summary>
        /// 获取信息获取器
        /// </summary>
        /// <returns></returns>
        IDataBaseDataGetter GetGetter();
        /// <summary>
        /// 获取游戏信息设置器
        /// </summary>
        /// <returns></returns>
        IGameSetter GetGameSetter();
        /// <summary>
        /// 获取链接设置器
        /// </summary>
        /// <returns></returns>
        ILinkSetter GetLinkSetter();
        /// <summary>
        /// 获取标签设置器
        /// </summary>
        /// <returns></returns>
        ITagSetter GetTagSetter();
    }
}
