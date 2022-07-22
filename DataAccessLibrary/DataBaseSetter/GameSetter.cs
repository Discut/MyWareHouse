using System;
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
            if (id < 0)
                return false;

            IDataAccess dataAccess = DataAccess.GetInstance();

            dataAccess.DeleteData(id, "Games");

            return true;
        }

        public IDictionary<string, object> InsertGame(IDictionary<string, object> gameInfo)
        {
            // 定义返回值
            //Dictionary<string, object> info = new Dictionary<string, object>();

            IDataAccess dataAccess = DataAccess.GetInstance();

            // 插入基础数据
            string command = "INSERT INTO Games(name,info,path,evaluation,favoriteId) VALUES ('" +
                (gameInfo.ContainsKey("name") ? gameInfo["name"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("info") ? gameInfo["info"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("path") ? gameInfo["path"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("evaluation") ? gameInfo["evaluation"].ToString() : null) + "','" +
                (gameInfo.ContainsKey("favoriteId") ? gameInfo["favoriteId"].ToString() : null) + "')";
            dataAccess.InsertData(command);


            string command2 = "SELECT id,name,info,path,evaluation,favoriteId FROM Games ORDER BY id DESC LIMIT 1";
            // 从数据库中获取最新行
            IList<IList<object>> lists = dataAccess.QueryData(command2);
            string[] keys = { "id", "name", "info", "path", "evaluation", "favoriteId" };
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

        public void InsertGamePlay(string id, DateTime dateTime)
        {
            IDataAccess dataAccess = DataAccess.GetInstance();

            string command = "INSERT INTO GamePlays(gameId,playTime) VALUES ('" + id + "','" + dateTime + "')";  
            dataAccess.InsertData(command);

        }

        public void InsertGameTags(string gameId, IList<IDictionary<string, object>> tags)
        {
            string deleteCommand = "DELETE FROM Games_Tags WHERE gameId=" + gameId;
            DataAccess.GetInstance().QueryData(deleteCommand);
            foreach (var item in tags)
            {
                IDictionary<string, object> tag = item; ;
                if (item["id"] == null)
                {
                    ITagSetter tagSetter = DataBaseFactory.GetInstance().GetTagSetter();
                    tag = tagSetter.InsertTag(item);
                }

                string insertCommand = "INSERT INTO Games_Tags VALUES('" + gameId + "','" + tag["id"] + "')";
                DataAccess.GetInstance().InsertData(insertCommand);
            }
        }

        public bool UpdateGame(IDictionary<string, object> data)
        {
            IDataAccess dataAccess = DataAccess.GetInstance();

            string command = "UPDATE Games SET" + " name='" + data["name"].ToString() + "'" +
                (data.ContainsKey("info") ? ",info='" + data["info"].ToString() : null) + "'" +
                (data.ContainsKey("favoriteId") ? ",favoriteId='" + (data["favoriteId"] == null ? "" : data["favoriteId"]) : null) + "'" +
                (data.ContainsKey("evaluation") ? ",evaluation='" + data["evaluation"].ToString() : null) + "'" +
                (data.ContainsKey("path") ? ",path='" + data["path"].ToString() : null) + "'" +
                " WHERE id=" + data["id"];

            dataAccess.UpdateData(command);
            return true;
        }
    }
}
