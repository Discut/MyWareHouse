using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Exception
{
    class NotFoundDataBasePathException: System.Exception
    {
        public NotFoundDataBasePathException(string massage): base(massage)
        {

        }
    }
}
