using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Exception
{
    class NotFoundSQLFileException: System.Exception
    {
        public NotFoundSQLFileException(string massage): base(massage)
        {

        }
    }
}
