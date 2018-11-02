using ServerApp.Data.Requests;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using ServerApp.Extencions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ServerApp.Models.Characters.Heroes;

namespace ServerApp.Data.Receivers
{
    public class HeroesViewManager : ViewManager<IHero, HeroViewModel>
    {
        public override void Run<TKey>(
            string                         commandCode,
            IGameContext                   context, 
            Expression<Func<IHero, TKey>>  keySelector, 
            OrderingStrategy               ordering, 
            int                            pageSize, 
            int                            pageNumber)
        {
            switch (commandCode)
            {
                case "":
                    break;
                default:
                    break;
            }

            IQueryable<IHero> models = context.Heroes.Request().OrderBy(keySelector, ordering);       
            
            models.Select()
        }        
    }
}
