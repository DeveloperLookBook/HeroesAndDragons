using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroHitsPayload : ReadCommandPayload<HeroHitsFilter, HitsOrdering>
    {
        public int HeroId { get; }        

        public ReadHeroHitsPayload(
            int            heroId, 
            HeroHitsFilter filterCode, 
            HitsOrdering   orderingCode, 
            OrderType      orderCode, 
            int            pageNumber, 
            int            pageSize)
            
            : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
            this.HeroId = heroId;
        }        
    }
}
