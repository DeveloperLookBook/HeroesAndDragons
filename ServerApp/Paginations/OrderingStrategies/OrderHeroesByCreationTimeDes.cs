using ServerApp.Data.Requests;
using ServerApp.Extencions;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.OrderingStrategies
{
    public class OrderHeroesByCreationTimeDes : ViewModelOrderingStrategy<IHero>
    {
        public override IQueryable<IHero> Order(IQueryable<IHero> models)
        {
            return models.OrderByCreationDate(OrderingStrategy.Descending);
        }
    }
}
