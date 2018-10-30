using System.Linq;
using ServerApp.Models;

namespace ServerApp.Paginations.OrderingStrategies
{
    public interface IPaginationOrderingStrategy<TModel> where TModel : class, IModel
    {
        IQueryable<TModel> Order(IQueryable<TModel> models);
    }
}