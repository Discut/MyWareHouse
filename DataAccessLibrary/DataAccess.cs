using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using DataAccessLibrary.Exception;

namespace DataAccessLibrary
{
    internal class DataAccess : IDataAccess
    {
        private string dbpath;
        private DataAccess()
        {
            
        }
        private static class Inner
        {
            public static IDataAccess DataAccess = new DataAccess();
        }
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        internal static IDataAccess GetInstance()
        {
            return Inner.DataAccess;
        }

        private void CheckDB()
        {
            if (dbpath == null)
                throw new NotFoundDataBasePathException("路径为空");
        }

        bool IDataAccess.DeleteData(int id, string tableName)
        {
            if (id < 0 || tableName == null)
                return false;
            CheckDB();
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "DELETE FROM " + tableName + " WHERE id=" + id;

                insertCommand.ExecuteReader();

                db.Close();
            }
            return true;
        }

        bool IDataAccess.InsertData(string command)
        {
            if (command == null)
                return false;
            CheckDB();
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = command;

                insertCommand.ExecuteReader();

                db.Close();
            }
            return true;
        }

        SqliteDataReader IDataAccess.QueryData(string command)
        {
            if (command == null)
                return null;
            CheckDB();
            SqliteDataReader query;
            //链接数据库
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    (command, db);
                
                query = selectCommand.ExecuteReader();

                db.Close();
            }

            return query;
        }

        bool IDataAccess.UpdateData(string command)
        {
            if (command == null)
                return false;
            CheckDB();
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = command;

                insertCommand.ExecuteReader();

                db.Close();
            }
            return true;
        }

        public void InitDataAccess(string dbName)
        {
            dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
        }
    }
}
