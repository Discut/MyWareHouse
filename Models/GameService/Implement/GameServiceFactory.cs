﻿using MyWareHouse.Models.Data;
using MyWareHouse.Models.GameService.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace MyWareHouse.Models.GameService
{
    class GameServiceFactory : IGameService
    {

        private GameServiceFactory() { }
        private static class Inner
        {
            public static GameServiceFactory Service = new GameServiceFactory();
        } 
        /// <summary>
        /// 获取游戏Getter服务
        /// </summary>
        /// <returns>游戏Geeter服务的实例</returns>
        public static IGameGetterService GetGameGetterService()
        {
            return GetInstance();
        }
        /// <summary>
        /// 获取游戏修改服务
        /// </summary>
        /// <returns>游戏修改服务实例</returns>
        public static IGameModifyService GetGameModifyService()
        {
            return GetInstance();
        }
        /// <summary>
        /// 获取游戏启动服务
        /// </summary>
        /// <returns>游戏启动服务实例</returns>
        public static IGameStartService GetGameStartService()
        {
            return GameStartByLauncher.Instance;
        }
        // 单例模式
        private static GameServiceFactory GetInstance()
        {
            return Inner.Service;
        }

        public IList<GameBar> GetGameBarList()
        {
            ObservableCollection<GameBar> gameBars = new ObservableCollection<GameBar>();

            IGameObjectService<Game> gameObjectService = GameObjectService.GetService();
            FavoriteService.IFavoriteGetter<Favorite> favoriteGetter = FavoriteService.FavoriteServiceFactory.Getter();
            IList<Favorite> lists = favoriteGetter.GetAllFavorites();

            foreach(Favorite favorite in lists)
            {
                IList<Game> lists1 = gameObjectService.GetFavoriteGames(favorite.Id);

                GameBar favoriteItem = new GameBar(null);
                favoriteItem.Title = favorite.Name;
                favoriteItem.Icon = new SymbolIcon(Symbol.Favorite);
                favoriteItem.Id = favorite.Id;
                favoriteItem.Children = new ObservableCollection<GameBar>();
                // 将游戏转化为侧边栏 并放入收藏夹侧边栏子项中
                foreach(Game game in lists1)
                {
                    //未设置Icon
                    GameBar gameBar = new GameBar(game);
                    favoriteItem.Children.Add(gameBar);
                }
                //将装载好的一个侧边栏放入侧边栏列表里
                gameBars.Add(favoriteItem);
            }
            // 查询未分类游戏
            IList<Game> unfavoriteGames = gameObjectService.GetFavoriteGames(null);
            GameBar unfavoriteItem = new GameBar(null);
            unfavoriteItem.Title = "未分类";
            unfavoriteItem.Icon = new SymbolIcon(Symbol.Favorite);
            unfavoriteItem.Children = new ObservableCollection<GameBar>();
            // 将游戏转化为侧边栏 并放入收藏夹侧边栏子项中
            foreach (Game game in unfavoriteGames)
            {
                //未设置Icon
                GameBar gameBar = new GameBar(game);
                unfavoriteItem.Children.Add(gameBar);
            }
            //将装载好的一个侧边栏放入侧边栏列表里
            gameBars.Add(unfavoriteItem);
            return gameBars;
        }

        public bool UpdataGame(Game game)
        {
            DataAccessLibrary.DataBaseFactory.GetInstance().GetGameSetter().UpdateGame(game.toDinctionary());

            IList<IDictionary<string, object>> tags = new List<IDictionary<string, object>>(); 
            foreach(Tag tag in game.Tags)
            {
                IDictionary<string, object> dictionaries = tag.toDinctionary();
                tags.Add(dictionaries);
            }
            DataAccessLibrary.DataBaseFactory.GetInstance().GetGameSetter().InsertGameTags(game.Id, tags);
            return true;
        }

        public Game InsertGame(Game game)
        {
            // 引入设置服务
            DataAccessLibrary.DataBaseSetter.IGameSetter setter = DataAccessLibrary.DataBaseFactory.GetInstance().GetGameSetter();


            Dictionary<string, object> info = new Dictionary<string, object>();
            info["name"] = game.Name;
            info["path"] = game.ApplicationPath;
            IDictionary<string, object> newGameInfo = setter.InsertGame(info);

            return GameFactory.GetGame(newGameInfo);
        }

        public Game DeleteGame(Game game)
        {
            // 引入设置服务
            DataAccessLibrary.DataBaseSetter.IGameSetter setter = DataAccessLibrary.DataBaseFactory.GetInstance().GetGameSetter();

            setter.DeleteGame(int.Parse(game.Id));

            return game;
        }
        public IList<Game> GetAllGamesBy(Favorite favorite)
        {
            // 定义返回对象
            ObservableCollection<Game> result = new ObservableCollection<Game>();
            // 引入设置服务
            DataAccessLibrary.DataBaseGetter.IDataBaseDataGetter getter = DataAccessLibrary.DataBaseFactory.GetInstance().GetGetter();

            IList<IDictionary<string, object>> lists = getter.GetGamesInFavorite(favorite.Id);

            foreach(IDictionary<string, object> dic in lists)
            {
                Game game = GameFactory.GetGame(dic);

                IList<IDictionary<string, object>> taginfos = getter.GetGameTags(game.Id);
                IList<Tag> tags = new List<Tag>();
                foreach(var taginfo in taginfos)
                {
                    Tag tag = new Tag();
                    tag.id = taginfo["id"].ToString();
                    tag.Title = taginfo["title"].ToString();
                    tags.Add(tag);
                }
                game.Tags = tags;
                result.Add(game);
            }

            return result;
        }

        public IList<IDictionary<string, object>> GetAllPlays()
        {
            // 引入设置服务
            DataAccessLibrary.DataBaseGetter.IDataBaseDataGetter getter = DataAccessLibrary.DataBaseFactory.GetInstance().GetGetter();
            return getter.GetAllPlays();
        }

        public void InsertPlay(string gameId, DateTime time)
        {
            // 引入设置服务
            DataAccessLibrary.DataBaseFactory.GetInstance().GetGameSetter().InsertGamePlay(gameId, time);
        }

        public string GetGamePlay(Game game)
        {
            string date = DataAccessLibrary.DataBaseFactory.GetInstance().GetGetter().GetPlayWith(game.Id);
            if (date != null)
                return date;
            else
                return null;
        }
    }
}
