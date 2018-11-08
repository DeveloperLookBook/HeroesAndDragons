using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroesPayload : ReadPayload<HeroesFilter, HeroesOrdering>
    {
        public ReadHeroesPayload(HeroesFilter filterCode, HeroesOrdering orderingCode, OrderType orderCode, int pageNumber, int pageSize) : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
        }

        public ReadHeroesPayload(int filterCode, int orderingCode, int orderType, int pageNumber, int pageSize) : base(filterCode, orderingCode, orderType, pageNumber, pageSize)
        {
        }

        public ReadHeroesPayload(string filterCodeName, string orderingCode, string orderType, int pageNumbe, int pageSize) : base(filterCodeName, orderingCode, orderType, pageNumbe, pageSize)
        {
        }
    }
}
