using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data
{
    public class Tag : ITransform
    {
        public string Title { get; set; }

        public string id { get; set; }

        public IDictionary<string, object> toDinctionary()
        {
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("title", Title);
            info.Add("id", id);
            return info;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
