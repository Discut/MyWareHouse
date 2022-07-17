using DataAccessLibrary;
using MyWareHouse.Models.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models
{
    class AppInitializer : IAppInitializer
    {
        private static class Inner
        {
            public static IAppInitializer initializer = new AppInitializer();
        }
        public static IAppInitializer Instance
        {
            get
            {
                return Inner.initializer;
            }
        }
        public async Task Init()
        {
            // 初始化数据库
            IDataBaseFactory dataBaseFactory = DataBaseFactory.GetInstance();
            await dataBaseFactory.Init();
            // 初始文件服务与化对象池
            await ImageFileService.Instance().InitAsync();
        }
    }
}
