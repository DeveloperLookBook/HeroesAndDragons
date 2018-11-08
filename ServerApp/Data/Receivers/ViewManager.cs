using ServerApp.Models;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data.Receivers
{
    public abstract class ViewManager<TModel, TViewModel, TFilter, TOrdering> 
        : IViewManager<TViewModel, TFilter, TOrdering>

        where TModel     : class, IModel
        where TViewModel : class, IViewModel
        where TFilter    : Enum
        where TOrdering  : Enum
    {
        public IView<TViewModel> View { get; protected set; }


        abstract public void Run(
            string        commandCode,
            IGameContext  gameContext,
            TFilter       viewModelsFilter,
            TOrdering     viewOrdering ,
            Order         viewOrder, 
            int           viewPageSize, 
            int           viewPageNumber);

        abstract protected IQueryable<TModel> Filter(
            IQueryable<TModel> models,
            TFilter            viewModelsFilter);

        abstract protected IQueryable<TModel> Order(
            IQueryable<TModel> models,
            TOrdering          viewOrdering,
            Order              viewOrder);
    }
}
