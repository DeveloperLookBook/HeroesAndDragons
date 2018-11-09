using Microsoft.AspNetCore.Mvc;
using ServerApp.Extencions;
using ServerApp.Data.Commands;
using ServerApp.Data.Commands.Payloads;
using ServerApp.Data.Repositories;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models.Characters;
using ServerApp.ViewModels;
using ServerApp.Data.Services.Helpers;

namespace ServerApp.Data.Handlers
{
    public class CommandHandler
    {
        #region PROPERTIES

        IRepository<IHero  > HeroRepository   { get; }
        IRepository<IDragon> DragonRepository { get; }
        IRepository<IHit   > HitRepository    { get; }

        #endregion

        #region CONSTRUCTORS

        public CommandHandler(IRepositoryFactory factory)
        {
            this.HeroRepository   = factory.Create(s => s.Heroes ());
            this.DragonRepository = factory.Create(s => s.Dragons());
            this.HitRepository    = factory.Create(s => s.Hits   ());
        }

        #endregion


        #region CREATE COMMAND HANDLERS

        public       Task<IActionResult> CreateHeroAsync      (CreateCommand<CommandHandler, CreateHeroPayload> command)
        {
            return Task.Run(() =>
            {
                var heroes    = this.HeroRepository.Request();
                var payload   = command.Payload;
                var validator = ViewModelValidatorFactory.Create(s => s.CreateHeroViewModelValidator());
                var result    = validator.Validate(payload.ViewModel);
                
                if (!result.IsValid)
                {
                    var state = result.ToModelStateDictionary();

                    return new BadRequestObjectResult(state) as IActionResult;
                }

                var heroName       = payload.ViewModel.Name;
                var isNameReserved = (heroes.FindByName(heroName, SearchType.Equal).Count() != 0);

                if (!isNameReserved) 
                {
                    return new BadRequestObjectResult(new { Message = "Name is reserved already."}) as IActionResult;
                }


            });            
        }
        public async Task<IActionResult> CreateHeroHitAsync   (CreateCommand<CommandHandler, CreateHitPayload > command)
        {
            var payload = command.Payload;
            var heroes  = this.HeroRepository.Request();
            var dragons = this.DragonRepository.Request();
            var hero    = await heroes.FindByIdAsync(payload.SourceId);

            if (hero   is null) return new NotFoundObjectResult(new { Message = "Hero not found."  });

            var dragon = await dragons.FindByIdAsync(payload.TargetId);

            if (dragon is null) return new NotFoundObjectResult(new { Message = "Dragon not found."});

            var hit = hero.Hit(dragon);
            
            this.HitRepository.Add(hit);
            this.DragonRepository.Update(dragon);

            return new OkObjectResult(new { Hit = hit, Dragon = dragon });
        }        
        public       Task<IActionResult> CreateDragonAsync    (CreateCommand<CommandHandler>                    command)
        {
            return Task.Run(() => 
            {
                var dragon = CharacterFactory.Create(s => s.Dragon());

                this.DragonRepository.Add(dragon);

                return new OkObjectResult(new { Dragon = dragon }) as IActionResult;
            });            
        }

        #endregion

        #region READ COMMAND HANDLERS

        public       Task<IActionResult> ReadHeroesAsync      (ReadCommand<CommandHandler, ReadHeroesPayload    > command)
        {
            return Task.Run(() =>
            {
                var heroes  = this.HeroRepository.Request();
                var payload = command.Payload;
                var view    = heroes
                                .FilterBy       (payload.FilterCode)
                                .OrderBy        (payload.OrderingCode, payload.OrderCode)
                                .ToHeroModelView(payload.Page.Number , payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });            
        }
        public       Task<IActionResult> ReadHeroHitsAsync    (ReadCommand<CommandHandler, ReadHeroHitsPayload  > command)
        {
            return Task.Run(() =>
            {
                var dragons = this.HitRepository.Request();
                var payload = command.Payload;
                var view    = dragons
                                .FilterBy           (payload.FilterCode)
                                .OrderBy            (payload.OrderingCode, payload.OrderCode)
                                .ToHeroHitsModelView(payload.Page.Number , payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });            
        }
        public       Task<IActionResult> ReadHeroesByNameAsync(ReadCommand<CommandHandler, ReadHeroesByNamePayload> command)
        {
            return Task.Run(() =>
            {
                var heroes  = this.HeroRepository.Request();
                var payload = command.Payload;
          
                var view    = heroes
                                .FindByName     (payload.Name ?? String.Empty, payload.SearchType)
                                .OrderBy        (payload.OrderingCode, payload.OrderCode)
                                .FilterBy       (payload.FilterCode)
                                .ToHeroModelView(payload.Page.Number, payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });            
        }
        public       Task<IActionResult> ReadDragonsAsync     (ReadCommand<CommandHandler, ReadDragonsPayload   > command)
        {
            return Task.Run(() =>
            {
                var dragons = this.DragonRepository.Request();
                var payload = command.Payload;
                var view    = dragons
                                .FilterBy         (payload.FilterCode)
                                .OrderBy          (payload.OrderingCode, payload.OrderCode)
                                .ToDragonModelView(payload.Page.Number , payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });
        }
        public async Task<IActionResult> ReadDragonByIdAsync  (ReadCommand<CommandHandler, ReadDragonByIdPayload> command)
        {            
            var payload = command.Payload;
            var dragons = this.DragonRepository.Request();
            var dragon  = await dragons.FindByIdAsync(payload.Id);

            if (dragon is null)
            {
                return new NotFoundObjectResult(new { Message = "Dragon not found." }) as IActionResult;
            }
            else
            {
                return new OkObjectResult(new { Dragon = dragon }) as IActionResult;
            }                     
        }

        #endregion
    }
}
