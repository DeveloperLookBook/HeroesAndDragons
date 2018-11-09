using ServerApp.Data.Services.Helpers;
using ServerApp.ViewModels;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroesByNamePayload : ReadCommandPayload<HeroesFilter, HeroesOrdering>
    {
        public SearchType SearchType { get; }
        public string     Name       { get; }


        public ReadHeroesByNamePayload(
            SearchType     searchType, 
            string         name, 
            HeroesFilter   filterCode, 
            HeroesOrdering orderingCode, 
            OrderType      orderCode, 
            int            pageNumber, 
            int            pageSize) 
            
            : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
            this.SearchType = searchType;
            this.Name       = name;
        }
    }
}
