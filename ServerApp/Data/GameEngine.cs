using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Commands;
using ServerApp.Data.Invokers;
using ServerApp.Data.Receivers;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using ServerApp.ViewModels.Dragons;
using ServerApp.ViewModels.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class GameEngine : IGameEngine
    {
        private IHero              Hero               { get; }
        private IDragon            Dragon             { get; }

        private RepositoryFactory        GameContext        { get; }
        private CommandInvoker     CommandController  { get; }

        private HeroViewManager  HeroesViewManager  { get; }
        private DragonViewManager DragonsViewManager { get; }
        

        public GameEngine(
            RepositoryFactory       gameContext,            
            ViewModelFactory  viewModelFactory)
        {
            this.GameContext        = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            this.CommandController  = new CommandInvoker         ();
            this.HeroesViewManager  = new HeroViewManager      ();
            this.DragonsViewManager = new DragonViewManager     ();
        }


        public Task<IActionResult> Signup   (ViewModels.Heroes.SignupHeroViewModel name)
        {
            return Task.Run(() =>
            {
                IActionResult actionResult = null;



                return actionResult;
            });
        }

        public bool Signin    (string token)
        {
            throw new NotImplementedException();
        }        

        public void HitDragon()
        {
            var command = new HitDragonCommand(this.GameContext, this.HeroesManager, this.Hero, this.Dragon);

            this.CommandController.StoreCommand(command);
            this.CommandController.ExecuteCommand();
        }

        public void CreateDragon()
        {

        }

        public IView<HeroViewModel> CreateView<TView>(
            HeroesFilter   filter,
            HeroesOrdering ordering, 
            Order          order, 
            int            pageSize, 
            int            pageNumber) 
            
            where TView : IView<HeroViewModel>
        {
            var command = new CreateHeroesViewCommand(this.HeroesViewManager, this.GameContext, filter, ordering, order, pageSize, pageNumber);

            this.CommandController.StoreCommand  (command);
            this.CommandController.ExecuteCommand();

            var view = this.HeroesViewManager.View;

            return view;
        }

        public IView<DragonViewModel> CreateView<TView>(
            DragonsFilter   filter,
            DragonsOrdering ordering,
            Order           order,
            int             pageSize,
            int             pageNumber)

            where TView : IView<DragonViewModel>
        {
            var command = new CreateDragonsViewCommand(this.DragonsViewManager, this.GameContext, filter, ordering, order, pageSize, pageNumber);

            this.CommandController.StoreCommand(command);
            this.CommandController.ExecuteCommand();

            var view = this.DragonsViewManager.View;

            return view;
        }        
    }    
}
