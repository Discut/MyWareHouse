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
        public static Game GetGame(string id, string name, string barImgPath, string applicationPath)
        {
            Game game = GameFactory.GetGame(id, name, applicationPath);
            game.CoverImgPath = barImgPath;
            return game;
        }
        public static Game GetGame(string id, string name, string barImgPath, string coverImgPath, string applicationPath)
        {
            Game game = GameFactory.GetGame(id, name, barImgPath, applicationPath);
            game.BarImgPath = coverImgPath;
            return game;
        }
        public static Game GetGame(string id, string name, string info, string barImgPath, string coverImgPath, string applicationPath)
        {
            Game game = GameFactory.GetGame(id, name, barImgPath, coverImgPath, applicationPath);
            game.Info = info;
            return game;
        }
        public static Game GetGame(string id, string name, string info, string barImgPath, string coverImgPath, string applicationPath, string evaluation)
        {
            Game game = GameFactory.GetGame(id, name, info, barImgPath, coverImgPath, applicationPath);
            game.Evaluation = evaluation;
            return game;
        }
        public static Game GetGame(IDictionary<string, object> info)
        {
             Game game = GetGame(
                info["id"].ToString(), 
                info["name"].ToString(), 
                info["info"].ToString(), 
                info["barImgPath"].ToString(), 
                info["coverImgPath"].ToString(), 
                info["path"].ToString(), 
                info["evaluation"].ToString());

            //if (info["id"] == null)
            //    game.
            return game;
        }
    }
}
