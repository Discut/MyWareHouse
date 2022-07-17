using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using DataAccessLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

                SqliteDataReader sqliteDataReader = insertCommand.ExecuteReader();

                db.Close();
            }
            return true;
        }

        IList<IList<object>> IDataAccess.QueryData(string command)
         {
            if (command == null)
                return null;
            ObservableCollection<IList<object>> result = new ObservableCollection<IList<object>>();

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

                int fieldCount = query.FieldCount;

                while (query.Read())
                {
                    ObservableCollection<object> row = new ObservableCollection<object>();
                    for (int index = 0; index < fieldCount; index++)
                    {
                        object value = query.IsDBNull(index) ? null : query.GetString(index);
                        row.Add(value);
                        //row[index] = value;
                    }
                    result.Add(row);
                }


                db.Close();
            }

            return (IList<IList<object>>)result;
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
