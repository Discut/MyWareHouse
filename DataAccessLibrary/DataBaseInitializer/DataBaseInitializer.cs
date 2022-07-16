using DataAccessLibrary.Exception;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataAccessLibrary.DataBaseInitializer
{
    class DataBaseInitializer : IDataBaseInitializer
    {
        private string dbName;
        public async Task<string> InitDB(string dbName)
        {
            this.dbName = dbName;
            await ApplicationData.Current.LocalFolder.CreateFileAsync(dbName, CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return dbpath;
        }

        public void InitTable(string dbPath, string command)
        {
            if (command == null)
                return;
            if (dbPath == null)
                throw new NotFoundDataBasePathException("在初始化数据库时，数据库路径为空");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                SqliteCommand createTable = new SqliteCommand(command, db);

                createTable.ExecuteReader();
                db.Close();
            }
        }
    }
}
