using System.Collections.Generic;
using System.Linq;
using ServerApp.Models;

namespace ServerApp.Data.Repositories
{   
    public interface IRepository
    {
        IQueryable<object> Request();

        void Add   (IEnumerable<object> models);
        void Add   (object              model );
        void Remove(IEnumerable<object> models);
        void Remove(object              model );
        void Update(IEnumerable<object> models);
        void Update(object              model );
    }

    public interface IRepository<TModel> : IRepository
        where TModel : class, IModel
    {
        new IQueryable<TModel> Request();

        void Add   (IEnumerable<TModel> models);
        void Add   (TModel              model );
        void Remove(IEnumerable<TModel> models);
        void Remove(TModel              model );
        void Update(IEnumerable<TModel> models);
        void Update(TModel              model );
    }
}