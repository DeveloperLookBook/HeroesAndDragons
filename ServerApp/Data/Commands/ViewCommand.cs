using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ServerApp.Data.Receivers;
using ServerApp.Data.Requests;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Models;
using ServerApp.Paginations;
using ServerApp.ViewModels;

namespace ServerApp.Data.Commands
{
    public class ViewCommand<TViewManager, TModel, TKey> : Command 
        where TViewManager : class, IViewManager<TModel>
        where TModel       : class, IModel
    {
        protected TViewManager     Manger     { get; }
        protected OrderingStrategy Ordering   { get; }
        protected string           Name       { get; }
        protected int              PageSize   { get; }
        protected int              PageNumber { get; }

        protected Expression<Func<TModel, TKey>> KeySelector     { get; private set; }


        protected ViewCommand(TViewManager manager, IGameContext context, Expression<Func<TModel, TKey>> keySelector, OrderingStrategy ordering, int pageSize, int pageNumber) : base(context)
        {
            this.Manger      = manager     ?? throw new ArgumentNullException(nameof(manager   ));
            this.KeySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
            this.Ordering    = ordering;
            this.PageSize    = pageSize;
            this.PageNumber  = pageNumber;
        }        


        public override void Execute()
        {
            this.Manger.Run(this.Name, this.Context, this.KeySelector, this.Ordering, this.PageSize, this.PageNumber);
        }
    }
}
