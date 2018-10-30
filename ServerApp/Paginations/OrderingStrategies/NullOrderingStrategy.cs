using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.OrderingStrategies
{
    public class NullOrderingStrategy : ViewModelOrderingStrategy<IModel>
    {
        public override IQueryable<IModel> Order(IQueryable<IModel> models)
        {
            return models;
        }
    }
}
