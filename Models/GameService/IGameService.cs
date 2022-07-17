using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWareHouse.Models.GameService
{
    interface IGameService: IGameGetterService, IGameModifyService
    {
        
    }
}
