using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseInitializer
{
    interface IDataBaseInitializer
    {
        /// <summary>
        /// 初始化数据库的表
        /// </summary>
        /// <param name="dbPath">数据库路径</param>
        /// <param name="command">初始化命令</param>
        void InitTable(string dbPath,string command);
        /// <summary>
        /// 初始化数据库文件
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <returns>返回数据库路径</returns>
        Task<string> InitDB(string dbName);
    }
}
