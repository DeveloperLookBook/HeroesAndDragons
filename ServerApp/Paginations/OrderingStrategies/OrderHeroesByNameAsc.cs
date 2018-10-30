using ServerApp.Models.Characters.Heroes;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Data.Requests;

namespace ServerApp.Paginations.OrderingStrategies
{
    public class OrderHeroesByNameAsc : ViewModelOrderingStrategy<IHero>
    {
        public override IQueryable<IHero> Order(IQueryable<IHero> models)
        {
            return models.OrderByName(OrderingStrategy.Ascending);
        }
    }
}
