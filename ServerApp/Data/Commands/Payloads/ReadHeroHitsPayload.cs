using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroHitsPayload : ReadPayload<HeroHitsFilter, HitsOrdering>
    {
        public int HeroId { get; }        

        public ReadHeroHitsPayload(int heroId, HeroHitsFilter filterCode, HitsOrdering orderingCode, OrderType orderCode, int pageNumber, int pageSize) 
            : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
            this.HeroId = heroId;
        }

        public ReadHeroHitsPayload(int heroId, int filterCode, int orderingCode, int orderType, int pageNumber, int pageSize) 
            : base(filterCode, orderingCode, orderType, pageNumber, pageSize)
        {
            this.HeroId = heroId;
        }

        public ReadHeroHitsPayload(int heroId, string filterCodeName, string orderingCode, string orderType, int pageNumbe, int pageSize) 
            : base(filterCodeName, orderingCode, orderType, pageNumbe, pageSize)
        {
            this.HeroId = heroId;
        }
    }
}
