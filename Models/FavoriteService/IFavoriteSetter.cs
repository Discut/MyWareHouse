﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.FavoriteService
{
    interface IFavoriteSetter<T>
    {
        /// <summary>
        /// 添加新的收藏夹
        /// </summary>
        /// <param name="title">收藏夹名称</param>
        /// <returns>返回插入的收藏夹</returns>
        T AddFavorite(string title = "未分类");
        /// <summary>
        /// 更新收藏夹名称
        /// </summary>
        /// <param name="id">收藏夹id</param>
        /// <param name="newName">新名称</param>
        void Rename(string id, string newName);
        /// <summary>
        /// 删除收藏夹
        /// </summary>
        /// <param name="id">收藏夹id</param>
        /// <returns>isSuccess</returns>
        bool DeleteFavorite(string id);
    }
}
