using MyWareHouse.Models.Data;
using MyWareHouse.Models.FavoriteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.FavoriteService
{
    static class FavoriteServiceFactory
    {
        public static IFavoriteGetter<Favorite> Getter()
        {
            return new Implement.FavoriteService();
        }

        public static IFavoriteSetter<Favorite> Setter()
        {
            return new Implement.FavoriteService();
        }
    }
}
