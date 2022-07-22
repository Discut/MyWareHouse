using MyWareHouse.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DataAccessLibrary;

namespace MyWareHouse.Models.GameService.Implement
{
    class GameObjectService : IGameObjectService<Game>
    {
        private GameObjectService() { }
        private static class Inner
        {
            public static IGameObjectService<Game> Service = new GameObjectService();
        }

        public static IGameObjectService<Game> GetService() { return Inner.Service; }

        public IDictionary<string, IList<Game>> GetDictionaryByFavorite()
        {
            // 定义结果集合
            Dictionary<string, IList<Game>> games = new Dictionary<string, IList<Game>>();
            // 从数据库获取所有游戏数据
            IDataBaseFactory dbFactory = DataBaseFactory.GetInstance();
            IList<IDictionary<string, object>> gameLists = dbFactory.GetGetter().GetAllGames();
            // 开始转换

            foreach(IDictionary<string, object> gameInfo in gameLists)
            {
                //gameInfo.
                Game game = GameFactory.GetGame(
                    gameInfo["id"].ToString(),
                    (string)gameInfo["name"],
                    (string)gameInfo["info"],
                    (string)gameInfo["path"],
                    (string)gameInfo["evaluation"]);


                // 获取game下的tag
                IList<IDictionary<string, object>> taginfos = DataAccessLibrary.DataBaseFactory.GetInstance().GetGetter().GetGameTags(game.Id);
                IList<Tag> tags = new List<Tag>();
                foreach (var taginfo in taginfos)
                {
                    Tag tag = new Tag();
                    tag.id = taginfo["id"].ToString();
                    tag.Title = taginfo["title"].ToString();
                    tags.Add(tag);
                }
                game.Tags = tags;



                IList<Game> observableCollections;
                if (!games.ContainsKey(gameInfo["favorite"].ToString()))
                {
                    observableCollections = new ObservableCollection<Game>();
                    games.Add(gameInfo["favorite"].ToString(), observableCollections);
                }
                else
                {
                    observableCollections = games[gameInfo["favorite"].ToString()];
                }
                observableCollections.Add(game);

            }

            return games as IDictionary<string, IList<Game>>;
        }

        public Game GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGame(string gameName)
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetLastGames()
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetFavoriteGames(string id)
        {
            // 定义结果集合
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            // 从数据库获取所有游戏数据
            IDataBaseFactory dbFactory = DataBaseFactory.GetInstance();
            IList<IDictionary<string, object>> gameLists = dbFactory.GetGetter().GetGamesInFavorite(id);

            // 开始转换

            foreach (IDictionary<string, object> gameInfo in gameLists)
            {
                //gameInfo.
                Game game = GameFactory.GetGame(gameInfo);

                // 获取game下的tag
                IList<IDictionary<string, object>> taginfos = DataAccessLibrary.DataBaseFactory.GetInstance().GetGetter().GetGameTags(game.Id);
                IList<Tag> tags = new List<Tag>();
                foreach (var taginfo in taginfos)
                {
                    Tag tag = new Tag();
                    tag.id = taginfo["id"].ToString();
                    tag.Title = taginfo["title"].ToString();
                    tags.Add(tag);
                }
                game.Tags = tags;


                games.Add(game);

            }

            return games;
        }
    }
}
