using System;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Paginations;
using ServerApp.ViewModels;

namespace ServerApp.Data.Receivers
{
    public interface IViewManager<TViewModel, TFilteringStrategy, TOrderingSource>
        where TViewModel : class, IViewModel
        where TFilteringStrategy : Enum
        where TOrderingSource : Enum
    {
        IView<TViewModel> View { get; }

        void Run(string commandCode, IGameContext gameContext, TFilteringStrategy viewFilteringStrategy, TOrderingSource viewOrderingSource, Order viewOrderingStrategy, int viewPageSize, int viewPageNumber);
    }
}