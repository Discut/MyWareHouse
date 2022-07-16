using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    public interface ILinkSetter
    {
        /// <summary>
        /// 更新链接信息
        /// </summary>
        /// <param name="data">等待更新的键值对数据</param>
        /// <returns>是否更新成功</returns>
        bool UpdateLink(IDictionary<string, object> data);
        /// <summary>
        /// 删除链接信息
        /// </summary>
        /// <param name="id">链接id</param>
        /// <returns>是否删除</returns>
        bool DeleteLink(int id);
        /// <summary>
        /// 插入链接信息
        /// </summary>
        /// <param name="linkInfo">链接信息键值对</param>
        /// <returns>已插入的带id信息</returns>
        IDictionary<string, object> InsertLink(IDictionary<string, object> linkInfo);
    }
}
