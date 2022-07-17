using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.Data
{
    class Game
    {
        internal Game() { }

        private string _name;
        private string _id;
        private string _barImgPath;
        private string _coverImgPath;
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


        public string CoverImgPath
        {
            get { return _coverImgPath; }
            set { _coverImgPath = value; }
        }


        public string BarImgPath
        {
            get { return _barImgPath; }
            set { _barImgPath = value; }
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

    }
}
