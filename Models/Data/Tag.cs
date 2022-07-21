using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data
{
    public class Tag
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
