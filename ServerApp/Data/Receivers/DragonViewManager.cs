using ServerApp.Data.UnitOfWorks;
using ServerApp.Extencions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DFilter   = ServerApp.Data.DragonsFilter;
using DOrdering = ServerApp.Data.DragonsOrdering;
using DOrder    = ServerApp.Data.Order;
using ServerApp.Models.Characters.Dragons;
using ServerApp.ViewModels.Dragons;

namespace ServerApp.Data.Receivers
{
    public class DragonViewManager : ViewManager<IDragon, DragonViewModel, DragonsFilter, DragonsOrdering>
    {
        public override void Run(
            string          commandCode, 
            IGameContext    gameContext,
            DragonsFilter   viewFilter,
            DragonsOrdering viewOrdering,
            Order           viewOrder, 
            int             viewPageSize, 
            int             viewPageNumber)
        {
            var dragons  = gameContext.Dragons.Request();
            var filter   = viewFilter;
            var target   = viewOrdering;
            var strategy = viewOrder;


            dragons = this.Filter(dragons, filter);
            dragons = this.Order (dragons, target, strategy);

            this.View = dragons.ToDragonModelView(viewPageNumber, viewPageSize);
        }

        protected override IQueryable<IDragon> Filter(
            IQueryable<IDragon> models,
            DragonsFilter       viewFilter)
        {
            switch (viewFilter)
            {
                case DFilter.All  : return models;
                case DFilter.Alive: return models.Alive();
                case DFilter.Dead : return models.Dead() ;

                default:            return models;
            }
        }

        protected override IQueryable<IDragon> Order(
            IQueryable<IDragon> models,
            DragonsOrdering     viewOrdering,
            Order               viewOrder)
        {
            IQueryable<IDragon> dragons = models;
            Order               order   = viewOrder;            

            switch (viewOrdering)
            {
                case DOrdering.ByName    when (order == DOrder.Ascending ): return dragons.OrderByAsc(d => d.Name   );
                case DOrdering.ByName    when (order == DOrder.Descending): return dragons.OrderByDes(d => d.Name   );
                case DOrdering.ByHealth  when (order == DOrder.Ascending ): return dragons.OrderByAsc(d => d.Health );
                case DOrdering.ByHealth  when (order == DOrder.Descending): return dragons.OrderByDes(d => d.Health );
                case DOrdering.ByCreated when (order == DOrder.Ascending ): return dragons.OrderByAsc(d => d.Created);
                case DOrdering.ByCreated when (order == DOrder.Descending): return dragons.OrderByDes(d => d.Created);

                default:                                                  return dragons.OrderByDes(h => h.Created);
            } 
        }
    }
}
