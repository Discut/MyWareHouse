﻿using MyWareHouse.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.GameService
{
    class GameStartByLauncher : IGameStartService
    {
        private static class Inner
        {
           public static IGameStartService gameStartService = new GameStartByLauncher();
        }
        /// <summary>
        /// 获取游戏启动服务的实例
        /// </summary>
        /// <returns></returns>
        public static IGameStartService GetInstance() { return Inner.gameStartService; }
        public bool StartGame(Game game)
        {
            string path = game.ApplicationPath;
            Windows.System.Launcher.LaunchUriAsync(new Uri("MyWarehouse://"+path));
            return true;
        }

        public bool StartGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public bool StartGame(string gameName)
        {
            throw new NotImplementedException();
        }
    }
}
