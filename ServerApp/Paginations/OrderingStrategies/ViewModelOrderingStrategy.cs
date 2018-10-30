using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.OrderingStrategies
{
    public abstract class ViewModelOrderingStrategy<TModel> : IPaginationOrderingStrategy<TModel> where TModel : class, IModel
    {
        public abstract IQueryable<TModel> Order(IQueryable<TModel> models);
    }
}
