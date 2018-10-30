using System.Collections.Generic;
using System.Linq;
using ServerApp.Models;

namespace ServerApp.Data.Repositories
{
    public interface IRepository<TModel> where TModel : class, IModel
    {
        void Add(IEnumerable<TModel> models);
        void Add(TModel model);
        void Remove(IEnumerable<TModel> models);
        void Remove(TModel model);
        IQueryable<TModel> Request();
        void Update(IEnumerable<TModel> models);
        void Update(TModel model);
    }
}