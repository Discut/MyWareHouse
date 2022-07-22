using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataBaseSetter
{
    class TagSetter : ITagSetter
    {
        public bool DeleteTag(int id)
        {
            return DataAccess.GetInstance().DeleteData(id, "Tags");
           
        }

        public IDictionary<string, object> InsertTag(IDictionary<string, object> tagInfo)
        {
            IDataAccess dataAccess = DataAccess.GetInstance();
            if (tagInfo["title"] != null)
            {
                string command = "INSERT INTO Tags(title) VALUES('" + tagInfo["title"].ToString() + "')";
                dataAccess.InsertData(command);

                string query = "SELECT id,title FROM Tags ORDER BY id DESC LIMIT 1";
                IList<IList<object>> lists = dataAccess.QueryData(query);
                string[] keys = { "id", "title" };
                IDictionary<string, object> info = Utili.DataTransiform.List2Dictionary(keys, lists[0]);
                return info;
            }
            return null;
        }

        public bool UpdateTag(IDictionary<string, object> data)
        {
            throw new NotImplementedException();
        }
    }
}
