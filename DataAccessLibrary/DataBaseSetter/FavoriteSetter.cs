using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    class FavoriteSetter : IFavoriteSetter
    {
        public bool DeleteFavorite(int id)
        {
            if (id < 0)
                return false;
            IDataAccess dataAccess = DataAccess.GetInstance();

            string command = "DELETE FROM Favorites WHERE id=" + id;
            dataAccess.UpdateData(command);
            return true;
        }

        public IDictionary<string, object> InsertFavorite(IDictionary<string, object> favoriteInfo)
        {
            IDataAccess dataAccess = DataAccess.GetInstance();

            string command = "INSERT INTO Favorites(name) VALUES ('" +
                (favoriteInfo.ContainsKey("name") ? favoriteInfo["name"].ToString() : null) + "')";
            dataAccess.InsertData(command);
            string command2 = "SELECT id,name FROM Favorites ORDER BY id DESC LIMIT 1";
            // 从数据库中获取最新行
            IList<IList<object>> lists = dataAccess.QueryData(command2);
            string[] keys = { "id", "name" };

            return Utili.DataTransiform.List2Dictionary(keys, lists[0]);
        }

        public bool UpdateFavorite(IDictionary<string, object> data)
        {
            IDataAccess dataAccess = DataAccess.GetInstance();

            string command = "UPDATE Favorites SET name='" + (data.ContainsKey("name") ? data["name"].ToString() : null) + "' WHERE id=" + (data.ContainsKey("id") ? data["id"].ToString() : null);
            dataAccess.UpdateData(command);

            return true;
        }
    }
}
