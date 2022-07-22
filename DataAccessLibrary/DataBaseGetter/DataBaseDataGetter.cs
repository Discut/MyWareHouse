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
            string command = "SELECT id,name,info,path,evaluation,favoriteId FROM Games ";
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach(IList<object> list in lists)
            {
                string[] keys = { "id", "name", "info", "path", "evaluation", "favoriteId" };
                IDictionary<string, object> gameInfo = Utili.DataTransiform.List2Dictionary(keys, list);


                gameInfoList.Add(gameInfo);
            }

            return gameInfoList;
        }

        public IList<IDictionary<string, object>> GetAllPlays()
        {
            // 定义返回对象
            ObservableCollection<IDictionary<string, object>> playList = new ObservableCollection<IDictionary<string, object>>();
            // 调用数据库
            IDataAccess dataAccess = DataAccess.GetInstance();
            string command = "SELECT gameId,playTime FROM GamePlays ORDER BY playTime DESC LIMIT 6";
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach (IList<object> list in lists)
            {
                string[] keys = { "gameId", "playTime"};
                IDictionary<string, object> gameInfo = Utili.DataTransiform.List2Dictionary(keys, list);
                playList.Add(gameInfo);
            }

            return playList;

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
            string command = "SELECT id,name,info,path,evaluation,favoriteId FROM Games WHERE favoriteId=" + (id == null ? "''" : id);
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach(IList<object> list in lists)
            {
                string[] keys = { "id", "name", "info", "path", "evaluation", "favoriteId" };
                IDictionary<string, object> gameInfo = Utili.DataTransiform.List2Dictionary(keys, list);
                gameInfoList.Add(gameInfo);
            }

            return gameInfoList;
        }

        public IList<string> GetGameTags(int gameId)
        {
            throw new NotImplementedException();
        }

        public IList<IDictionary<string, object>> GetGameTags(string id)
        {
            // 调用数据库
            IDataAccess dataAccess = DataAccess.GetInstance();
            // 定义返回数据
            IList<IDictionary<string, object>> result = new List<IDictionary<string, object>>(); 

            string command = "SELECT Tags.id,Tags.title FROM Tags JOIN Games_Tags ON Tags.id=Games_Tags.tagId WHERE Games_Tags.gameId=" + id;
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach (IList<object> list in lists)
            {
                string[] keys = { "id", "title" };
                IDictionary<string, object> tag = Utili.DataTransiform.List2Dictionary(keys, list);
                result.Add(tag);
            }
            return result;
        }

        public string GetPlayWith(string gameId)
        {
            string time = null;
            // 调用数据库
            IDataAccess dataAccess = DataAccess.GetInstance();
            string command = "SELECT playTime FROM GamePlays WHERE gameId='" + gameId + "' ORDER BY playTime DESC LIMIT 1";
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach (IList<object> list in lists)
            {
                string[] keys = { "playTime" };
                IDictionary<string, object> playInfo = Utili.DataTransiform.List2Dictionary(keys, list);
                time = playInfo["playTime"].ToString();
            }

            return time;
        }
    }
}
