﻿using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroesPayload : ReadCommandPayload<HeroesFilter, HeroesOrdering>
    {
        public ReadHeroesPayload(
            HeroesFilter   filterCode, 
            HeroesOrdering orderingCode, 
            OrderType      orderCode, 
            int            pageNumber, 
            int            pageSize) 
            
            : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
        }        
    }
}
