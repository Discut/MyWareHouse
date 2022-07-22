using DataAccessLibrary.DataBaseGetter;
using DataAccessLibrary.DataBaseInitializer;
using DataAccessLibrary.DataBaseSetter;
using DataAccessLibrary.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataAccessLibrary
{
    public class DataBaseFactory : IDataBaseFactory
    {
        private static class Inner
        {
            public static IDataBaseFactory DataBaseFactory = new DataBaseFactory();
        }
        public static IDataBaseFactory GetInstance()
        {
            return Inner.DataBaseFactory;
        }

        private string dbName = "MyWarehouseDB.db";
        private string[] tables = { @"Assets\Sql\Favorites.sql", @"Assets\Sql\Games.sql", @"Assets\Sql\Links.sql", @"Assets\Sql\Tags.sql", @"Assets\Sql\Games_Tags.sql", @"Assets\Sql\GamePlays.sql" };

        private DataBaseFactory()
        {
        }

        public IGameSetter GetGameSetter()
        {
            return new GameSetter();
        }

        public IDataBaseDataGetter GetGetter()
        {
            //throw new NotImplementedException();
            return new DataBaseGetter.DataBaseDataGetter();
        }

        public ILinkSetter GetLinkSetter()
        {
            throw new NotImplementedException();
        }

        public ITagSetter GetTagSetter()
        {
            return new TagSetter();
        }

        public async Task<bool> Init()
        {
            IDataBaseInitializer dataBaseInitializer = new DataBaseInitializer.DataBaseInitializer();
            // 初始化数据库
            string dbPath = await dataBaseInitializer.InitDB(dbName);
            //初始化表
            foreach (string tableSql in tables)
            {
                string command;
                StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFile file = await InstallationFolder.GetFileAsync(tableSql);
                if (File.Exists(file.Path))
                {
                    command = File.ReadAllText(file.Path);
                }
                else
                {
                    throw new NotFoundSQLFileException("初始化数据库时，未发现sql文件");
                }
                dataBaseInitializer.InitTable(dbPath, command);
                
            }
            //初始化 DataAcess
            DataAccess.GetInstance().InitDataAccess(dbName);

            return true;
        }

        public IFavoriteSetter GetFavoriteSetter()
        {
            return new FavoriteSetter();
        }

        public IFavoriteGetter GetFavoriteGetter()
        {
            return new FavoriteGetter();
        }
    }
}
