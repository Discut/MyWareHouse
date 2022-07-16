using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.DataAccess.Exception
{
    class NotFoundSQLFileException: System.Exception
    {
        public NotFoundSQLFileException(string massage): base(massage)
        {

        }
    }
}
