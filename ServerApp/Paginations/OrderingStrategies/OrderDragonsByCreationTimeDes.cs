using ServerApp.Models.Characters.Dragons;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Data.Requests;

namespace ServerApp.Paginations.OrderingStrategies
{
    public class OrderDragonsByCreationTimeDes : ViewModelOrderingStrategy<IDragon>
    {
        public override IQueryable<IDragon> Order(IQueryable<IDragon> models)
        {
            return models.OrderByCreationDate(OrderingStrategy.Descending);
        }
    }
}
