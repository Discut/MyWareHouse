using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseGetter
{
    class FavoriteGetter : IFavoriteGetter
    {
        public IList<IDictionary<string, object>> GetAllFavorites()
        {
            // 定义返回对象
            ObservableCollection<IDictionary<string, object>> favoriteInfoList = new ObservableCollection<IDictionary<string, object>>();
            // 调用数据库
            IDataAccess dataAccess = DataAccess.GetInstance();
            string command = "SELECT id,name FROM Favorites";
            IList<IList<object>> lists = dataAccess.QueryData(command);
            foreach (IList<object> list in lists)
            {
                string[] keys = { "id", "name" };
                IDictionary<string, object> favoriteInfo = Utili.DataTransiform.List2Dictionary(keys, list);
                favoriteInfoList.Add(favoriteInfo);
            }

            return favoriteInfoList;
        }
    }
}
