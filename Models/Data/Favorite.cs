using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data
{
    /// <summary>
    /// 收藏夹数据类
    /// </summary>
    class Favorite: ITransform
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }

        public IDictionary<string, object> toDinctionary()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("id", Id);
            dic.Add("name", Name);
            return new Dictionary<string, object>();
        }
    }
}
