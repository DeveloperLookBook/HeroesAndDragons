using ServerApp.Data.UnitOfWorks;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Paginations.OrderingStrategies;
using ServerApp.Paginations.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.Builder
{
    public class HeroesViewModelBuilder : ViewModelBuilder<IHero, HeroesOrderingStrategy>
    {
        public HeroesViewModelBuilder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IPaginationOrderingStrategy<IHero> CreateOrderingStrategy(HeroesOrderingStrategy value)
        {
            switch (value)
            {
                case HeroesOrderingStrategy.OrderByNameAsc        : return new OrderHeroesByNameAsc        ();
                case HeroesOrderingStrategy.OrderByNameDes        : return new OrderHeroesByNameDes        ();
                case HeroesOrderingStrategy.OrderByCreationTimeAsc: return new OrderHeroesByCreationTimeAsc();
                case HeroesOrderingStrategy.OrderByCreationTimeDes: return new OrderHeroesByCreationTimeDes();

                default: throw new ArgumentException("Selected Heroes ordering strategy doesn't exist.", nameof(value));
            }
        }

        protected override IViewModelParams CreateViewModelParams(ViewModelParamsType value)
        {
            switch (value)
            {
                case ViewModelParamsType.Default: return new DefaultViewModelParams();
                default: throw new ArgumentException("Selected view model parameter instance doesn't exist.", nameof(value));
            }
        }
    }
}
