using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data
{
    class GameFactory
    {
        public static Game GetGame(string name, string applicationPath)
        {
            return new Game()
            {
                Name = name,
                ApplicationPath = applicationPath
            };
        }
        public static Game GetGame(string id, string name, string applicationPath)
        {
            Game game = GetGame(name,applicationPath);
            game.Id = id;
            return game;
        }
        public static Game GetGame(string id, string name, string info, string applicationPath)
        {
            Game game = GameFactory.GetGame(id, name, applicationPath);
            game.Info = info;
            return game;
        }
        public static Game GetGame(string id, string name, string info, string applicationPath, string evaluation)
        {
            Game game = GameFactory.GetGame(id, name, info, applicationPath);
            game.Evaluation = evaluation;
            return game;
        }
        public static Game GetGame(IDictionary<string, object> info)
        {
             Game game = GetGame(
                info["id"].ToString(), 
                info["name"].ToString(), 
                info["info"].ToString(),
                info["path"].ToString(), 
                info["evaluation"].ToString());
            if (info.ContainsKey("id"))
                game.FavoriteId= info["favoriteId"].ToString();

            //if (info["id"] == null)
            //    game.
            return game;
        }
    }
}
