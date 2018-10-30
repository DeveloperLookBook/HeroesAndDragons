using ServerApp.Data.Repositories;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Models;
using ServerApp.Paginations.FormattingStrategies;
using ServerApp.Paginations.OrderingStrategies;
using ServerApp.Paginations.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.Builder
{
    public abstract class ViewModelBuilder<TModel, TOredringStrategyEnum> 
        where TModel                : class, IModel
        where TOredringStrategyEnum : Enum
    {
        protected IUnitOfWork                                     UnitOfWork { get;      }
        protected IQueryable<TModel>                              Models     { get; set; }
        private   IViewModelParams                                Parameters { get; set; }
        private   int                                             PageSize   { get; set; }
        private   int                                             PageNumber { get; set; }
        //protected IPaginationOrderingStrategy<TModel>             OrderingStrategy     { get; set; }
        //protected IViewModeFormattingStrategy<TModel, TViewModel> FormattingStrategy   { get; set; }


        public ViewModelBuilder(IUnitOfWork unitOfWork) 
        {
            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public void SetViewModelParams   (ViewModelParamsType   value = default) => this.CreateViewModelParams(value);
        public void SetActualPageSize    (int                   value          ) => this.PageSize   = value;
        public void SetActualPageNumber  (int                   value          ) => this.PageNumber = value;
        public void SetFormattingStrategy()
        public void SetOrderingStrategy  (TOredringStrategyEnum value          ) => this.Models = this.CreateOrderingStrategy(value).Order(this.Models);


        protected abstract IViewModelParams                    CreateViewModelParams (ViewModelParamsType   value);
        protected abstract IPaginationOrderingStrategy<TModel> CreateOrderingStrategy(TOredringStrategyEnum value);
        public    virtual  object                              Build();
    }
}
