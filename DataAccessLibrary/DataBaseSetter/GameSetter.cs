﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    class GameSetter : IGameSetter
    {
        public bool DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> InsertGame(IDictionary<string, object> gameInfo)
        {
            // 定义返回值
            //Dictionary<string, object> info = new Dictionary<string, object>();

            IDataAccess dataAccess = DataAccess.GetInstance();


            string command = "INSERT INTO Games(name,info,path,barImgPath,coverImgPath,evaluation,favoriteId) VALUES ('" +
                (gameInfo.ContainsKey("name") ? gameInfo["name"].ToString() : null) + "','"+
                (gameInfo.ContainsKey("info") ? gameInfo["info"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("path") ? gameInfo["path"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("barImgPath") ? gameInfo["barImgPath"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("coverImgPath") ? gameInfo["coverImgPath"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("evaluation") ? gameInfo["evaluation"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("favoriteId") ? gameInfo["favoriteId"].ToString() : null) + "')";
            dataAccess.InsertData(command);
            string command2 = "SELECT id,name,info,path,barImgPath,coverImgPath,evaluation,favoriteId FROM Games ORDER BY id DESC LIMIT 1";
            // 从数据库中获取最新行
            IList<IList<object>> lists = dataAccess.QueryData(command2);
            string[] keys = { "id", "name", "info", "path", "barImgPath", "coverImgPath", "evaluation", "favoriteId" };
            IDictionary<string, object> info = Utili.DataTransiform.List2Dictionary(keys, lists[0]);

            //foreach (IList<object> list in lists)
            //{
            //    info["id"] = list[0];
            //    info["name"] = list[1];
            //    info["info"] = list[2];
            //    info["path"] = list[3];
            //    info["barImgPath"] = list[4];
            //    info["coverImgPath"] = list[5];
            //    info["evaluation"] = list[6];
            //    info["favorite"] = list[7];
            //}
            return info;
        }

        public bool UpdateGame(IDictionary<string, object> data)
        {
            throw new NotImplementedException();
        }
    }
}
