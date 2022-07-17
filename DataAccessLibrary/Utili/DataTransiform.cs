using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Utili
{
     static class DataTransiform
    {
        public static IDictionary<string,object> List2Dictionary(string[] keys, IList<object> values)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            for(int index = 0; index < keys.Length; index++)
            {
                result.Add(keys[index], values[index]);
            }

            return result;
        }
    }
}
