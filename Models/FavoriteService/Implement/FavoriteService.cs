using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWareHouse.Models.Data;
using MyWareHouse.Models.Data.Factory;
using MyWareHouse.Models.FavoriteService;

namespace MyWareHouse.Models.FavoriteService.Implement
{
    /// <summary>
    /// 收藏夹实现类
    /// </summary>
    class FavoriteService : IFavoriteGetter<Favorite>, IFavoriteSetter<Favorite>
    {
        public Favorite AddFavorite(string title = "未分类")
        {
            DataAccessLibrary.DataBaseSetter.IFavoriteSetter setter = DataAccessLibrary.DataBaseFactory.GetInstance().GetFavoriteSetter();
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("name", title);
            IDictionary<string, object> newFavorite = setter.InsertFavorite(info);
            return FavoriteFactory.GetFavorite(newFavorite);
        }

        public IList<Favorite> GetAllFavorites()
        {
            // 创建返回对象
            List<Favorite> result = new List<Favorite>();
            DataAccessLibrary.DataBaseGetter.IFavoriteGetter getter = DataAccessLibrary.DataBaseFactory.GetInstance().GetFavoriteGetter();

            IList<IDictionary<string, object>> lists = getter.GetAllFavorites();
            foreach(IDictionary < string, object> dic in lists)
            {
                result.Add(Data.Factory.FavoriteFactory.GetFavorite(dic));
            }
            return result;
        }
    }
}
