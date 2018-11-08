using ServerApp.Data.UnitOfWorks;
using ServerApp.Extencions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ServerApp.Models.Characters.Heroes;
using HFilter   = ServerApp.Data.HeroesFilter;
using HOrdering = ServerApp.Data.HeroesOrdering;
using HOrder    = ServerApp.Data.Order;
using ServerApp.ViewModels.Heroes;

namespace ServerApp.Data.Receivers
{
    public class HeroViewManager : ViewManager<IHero, HeroViewModel, HeroesFilter, HeroesOrdering>
    {
        public override void Run(
            string         commandCode, 
            IGameContext   gameContext,
            HeroesFilter   viewModelsFilter,
            HeroesOrdering viewOrdering, 
            Order          viewOrder, 
            int            viewPageSize, 
            int            viewPageNumber)
        {
            var heroes   = gameContext.Heroes.Request();

            heroes = this.Filter(heroes, viewModelsFilter);
            heroes = this.Order (heroes, viewOrdering, viewOrder);

            this.View = heroes.ToHeroModelView(viewPageSize, viewPageNumber);
        }

        protected override IQueryable<IHero> Filter(
            IQueryable<IHero> models, 
            HeroesFilter      viewFilter)
        {
            switch (viewFilter)
            {
                case HFilter.All: return models;
                default:          return models;
            }
        }

        override protected IQueryable<IHero> Order(
            IQueryable<IHero> models, 
            HeroesOrdering    viewOrdering, 
            Order             viewOrder)
        {
            Order order = viewOrder;
            
            switch (viewOrdering)
            {
                case HOrdering.ByName           when order == HOrder.Ascending : return models.OrderByAsc(h => h.Name           );
                case HOrdering.ByName           when order == HOrder.Descending: return models.OrderByDes(h => h.Name           );
                case HOrdering.ByCreated        when order == HOrder.Ascending : return models.OrderByAsc(h => h.Created        );
                case HOrdering.ByCreated        when order == HOrder.Descending: return models.OrderByDes(h => h.Created        );
                case HOrdering.ByWeaponName     when order == HOrder.Ascending : return models.OrderByAsc(h => h.Weapon.Name    );
                case HOrdering.ByWeaponName     when order == HOrder.Descending: return models.OrderByDes(h => h.Weapon.Name    );
                case HOrdering.ByWeaponStrength when order == HOrder.Ascending : return models.OrderByAsc(h => h.Weapon.Strength);
                case HOrdering.ByWeaponStrength when order == HOrder.Descending: return models.OrderByDes(h => h.Weapon.Strength);

                default:                                                         return models.OrderByDes(h => h.Created        );
            }            
        }

    }
}
