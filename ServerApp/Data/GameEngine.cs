using ServerApp.Data.Commands;
using ServerApp.Data.Invokers;
using ServerApp.Data.Receivers;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Models;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class GameEngine
    {
        private GameContext        Context        { get; }
        private CommandControl     Controller     { get; }
        private HeroesViewManager  HeroesViewUnit { get; }
        //private DragonsViewUnit DragonsViewUnit { get; }

        public void CreateHeroView<TModel, TKey> (
            HeroViewSelector                      viewSelector, 
            Expression<Func<IHero, TKey>>         keySelector, 
            OrderingStrategy                      ordering, 
            int                                   pageSize, 
            int                                   pageNumber)  
            
            where TModel : class, IHero
        {
            var command  = AllHeroesView<TKey>();


            var c = new 
            c.

            
        }

        public void CreateView<TViewModel, TModel, TKey>(Expression<Func<IDragon, TKey>> keySelector, OrderingStrategy ordering, int pageSize, int pageNumber)
            where TViewModel : class, IViewModel
            where TModel : class, IHero, IDragon
        {
        }
        }
}
