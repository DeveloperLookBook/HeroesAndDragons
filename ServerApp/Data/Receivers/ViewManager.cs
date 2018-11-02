using ServerApp.Data.UnitOfWorks;
using ServerApp.Extencions;
using ServerApp.Models;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data.Receivers
{
    public abstract class ViewManager<TModel, TViewModel> : IViewManager<TModel>
        where TModel     : class, IModel
        where TViewModel : class, IViewModel
    {
        public View<TViewModel> View { get; protected set; }


        public abstract void Run<TKey>(
            string                         commandCode,
            IGameContext                   context, 
            Expression<Func<TModel, TKey>> keySelector, 
            OrderingStrategy               ordering, 
            int                            pageSize, 
            int                            pageNumber);
    }
}
