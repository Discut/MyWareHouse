using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLibrary.DataBaseGetter
{
    class DataBaseDataGetter : IDataBaseDataGetter
    {
        public IList<IDictionary<string, object>> GetAllGames()
        {
            // 定义返回对象
            ObservableCollection<IDictionary<string, object>> gameInfoList = new ObservableCollection<IDictionary<string, object>>();
            // 调用数据库
            IDataAccess dataAccess = DataAccess.GetInstance();
            string command = "SELECT id,name,info,path,barImgPath,coverImgPath,evaluation,favoriteId FROM Games ";
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach(IList<object> list in lists)
            {
                string[] keys = { "id", "name", "info", "path", "barImgPath", "coverImgPath", "evaluation", "favoriteId" };
                IDictionary<string, object> gameInfo = Utili.DataTransiform.List2Dictionary(keys, list);

                //Dictionary<string, object> gameInfo = new Dictionary<string, object>();
                //gameInfo["id"] = list[0];
                //gameInfo["name"] = list[1];
                //gameInfo["info"] = list[2];
                //gameInfo["path"] = list[3];
                //gameInfo["barImgPath"] = list[4];
                //gameInfo["coverImgPath"] = list[5];
                //gameInfo["evaluation"] = list[6];
                //gameInfo["favorite"] = list[7];

                gameInfoList.Add(gameInfo);
            }

            return gameInfoList;
        }

        public IList<IDictionary<string, object>> GetGameLinks(int gameId)
        {
            throw new NotImplementedException();
        }

        public IList<IDictionary<string, object>> GetGamesInFavorite(string id)
        {
            // 定义返回对象
            ObservableCollection<IDictionary<string, object>> gameInfoList = new ObservableCollection<IDictionary<string, object>>();
            // 调用数据库
            IDataAccess dataAccess = DataAccess.GetInstance();
            string command = "SELECT id,name,info,path,barImgPath,coverImgPath,evaluation,favoriteId FROM Games WHERE favoriteId=" + (id == null ? "''" : id);
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach(IList<object> list in lists)
            {
                string[] keys = { "id", "name", "info", "path", "barImgPath", "coverImgPath", "evaluation", "favoriteId" };
                IDictionary<string, object> gameInfo = Utili.DataTransiform.List2Dictionary(keys, list);
                gameInfoList.Add(gameInfo);
            }

            return gameInfoList;
        }

        public IList<string> GetGameTags(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
