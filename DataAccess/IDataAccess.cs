using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.DataAccess
{
    internal interface IDataAccess
    {
        /// <summary>
        /// 初始化数据获取器
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        void InitDataAccess(string dbName);
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="command">查询命令</param>
        /// <returns>查询结果阅读器</returns>
        SqliteDataReader QueryData(string command);
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="command">插入命令</param>
        /// <returns>是否执行成功</returns>
        bool InsertData(string command);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">数据元组主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>是否删除</returns>
        bool DeleteData(int id, string tableName);
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="command">更新命令</param>
        /// <returns>是否更新成功</returns>
        bool UpdateData(string command);
    }
}
