using ServerApp.Data.UnitOfWorks;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Paginations.OrderingStrategies;
using ServerApp.Paginations.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.Builder
{
    public class DragonsViewModelBuilder : ViewModelBuilder<IDragon, DragonsOrderingStrategy>
    {
        public DragonsViewModelBuilder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IPaginationOrderingStrategy<IDragon> CreateOrderingStrategy(DragonsOrderingStrategy value)
        {
            switch (value)
            {
                case DragonsOrderingStrategy.OrderByNameAsc        : return new OrderDragonsByNameAsc        ();
                case DragonsOrderingStrategy.OrderByNameDes        : return new OrderDragonsByNameDes        ();
                case DragonsOrderingStrategy.OrderByHealthAsc      : return new OrderDragonsByHealthAsc      ();
                case DragonsOrderingStrategy.OrderByHealthDes      : return new OrderDragonsByHealthDes      ();
                case DragonsOrderingStrategy.OrderByCreationTimeAsc: return new OrderDragonsByCreationTimeAsc();
                case DragonsOrderingStrategy.OrderByCreationTimeDes: return new OrderDragonsByCreationTimeDes();

                default: throw new ArgumentException("Selected Dragons ordering strategy doesn't exist.", nameof(value));
            }
        }
    }
}
