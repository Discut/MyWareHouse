using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    public interface ITagSetter
    {
        /// <summary>
        /// 更新标签信息
        /// </summary>
        /// <param name="data">等待更新的键值对数据</param>
        /// <returns>是否更新成功</returns>
        bool UpdateTag(IDictionary<string, object> data);
        /// <summary>
        /// 删除标签信息
        /// </summary>
        /// <param name="id">标签id</param>
        /// <returns>是否删除</returns>
        bool DeleteTag(int id);
        /// <summary>
        /// 插入标签信息
        /// </summary>
        /// <param name="tagInfo">标签信息键值对</param>
        /// <returns>已插入的带id信息</returns>
        IDictionary<string, object> InsertTag(IDictionary<string, object> tagInfo);
    }
}
