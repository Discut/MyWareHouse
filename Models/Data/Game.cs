using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data
{
    class Game : ITransform
    {
        internal Game() { }

        private string _name;
        private string _id;
        private string _applicationPath;
        private string _favorite = "未分类";
        private string _favoriteId;
        private string _info;
        private string _evaluation;
        private string[] tags;

        public string FavoriteId
        {
            get { return _favoriteId; }
            set { _favoriteId = value; }
        }

        public string Evaluation
        {
            get { return _evaluation; }
            set { _evaluation = value; }
        }

        public string[] Tags
        {
            get { return tags; }
            set { tags = value; }
        }


        public string ApplicationPath
        {
            get { return _applicationPath; }
            set { _applicationPath = value; }
        }

        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }


        public string Favorite
        {
            get { return _favorite; }
            set { _favorite = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public IDictionary<string, object> toDinctionary()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("id", Id);
            dic.Add("name", Name);
            dic.Add("info", Info);
            dic.Add("favoriteId", FavoriteId);
            dic.Add("evaluation", Evaluation);
            dic.Add("path", ApplicationPath);
            return dic;
        }
    }
}
