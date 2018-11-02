using ServerApp.Data.Receivers;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public class AllHeroesView<TKey> : ViewCommand<HeroesViewManager, IHero, TKey>
    {
        public AllHeroesView(
            HeroesViewManager             manager, 
            IGameContext                  context, 
            Expression<Func<IHero, TKey>> keySelector, 
            OrderingStrategy              ordering, 
            int                           pageSize, 
            int                           pageNumber) 

            : base(manager, context, keySelector, ordering, pageSize, pageNumber)
        {
        }
    }
}
