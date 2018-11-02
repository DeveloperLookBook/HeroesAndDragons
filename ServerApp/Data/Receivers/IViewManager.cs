using System;
using System.Linq.Expressions;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Models;

namespace ServerApp.Data.Receivers
{
    public interface IViewManager<TModel> where TModel : class, IModel
    {
        void Run<TKey>(string commandCode, IGameContext context, Expression<Func<TModel, TKey>> keySelector, OrderingStrategy ordering, int pageSize, int pageNumber);
    }
}