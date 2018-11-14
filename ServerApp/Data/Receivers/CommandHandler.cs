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
using ServerApp.Data.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using ServerApp.Models.Weapons;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Data.Receivers
{
    public class CommandHandler
    {
        #region PROPERTIES

        IRepository<Hero>    HeroRepository   { get; }
        IRepository<Dragon>  DragonRepository { get; }
        IRepository<Hit>     HitRepository    { get; }
        IRepository<Weapon>  WeaponRepository { get; }

        IConfiguration       Configuration    { get; }

        IQueryable<IHero>    Heroes           { get; }
        IQueryable<IDragon>  Dragons          { get; }
        IQueryable<IHit>     Hits             { get; }
        IQueryable<IWeapon>  Weapons          { get; }

        TokenDirector        TokenDirector    { get; }

        #endregion

        #region CONSTRUCTORS

        public CommandHandler(IConfiguration configuration, IRepositoryFactory factory)
        {
            if (configuration is null) { throw new ArgumentNullException(nameof(configuration)); }
            if (factory       is null) { throw new ArgumentNullException(nameof(factory      )); }

            this.Configuration    = configuration;

            this.HeroRepository   = factory.Create(s => s.Heroes ());
            this.DragonRepository = factory.Create(s => s.Dragons());
            this.HitRepository    = factory.Create(s => s.Hits   ());
            this.WeaponRepository = factory.Create(s => s.Weapons());

            this.Heroes           = this.HeroRepository  .Request();
            this.Dragons          = this.DragonRepository.Request();
            this.Hits             = this.HitRepository   .Request();
            this.Weapons          = this.WeaponRepository.Request();

            this.TokenDirector    = new TokenDirector();
        }

        #endregion


        #region CREATE COMMAND HANDLERS

        public Task<IActionResult> CreateHeroAsync      (CreateCommand<CommandHandler, CreateHeroPayload> command)
        {
            return Task.Run(() =>
            {
                // Validate hero name format:
                var payload            = command.Payload;
                var viewModelValidator = ViewModelValidatorFactory.Create(s => s.CreateHeroViewModelValidator());
                var validationResult   = viewModelValidator.Validate(payload.ViewModel);
                var modelState         = validationResult.ToModelStateDictionary();

                if (!validationResult.IsValid) return new ConflictObjectResult(modelState) as IActionResult;


                //  Check hero name uniqueness:
                var isNameReserved = !(this.Heroes.FindByName(payload.ViewModel.Name, SearchType.Equal).IsEmpty());

                if (isNameReserved) return new BadRequestObjectResult(new { 
                    Message = "Name is reserved already."
                }) as IActionResult;               
                

                // Create and save new hero with weapon:
                var hero = CharacterFactory.Create(s => s.Hero(payload.ViewModel.Name));

                this.WeaponRepository.Add(hero.Weapon);
                this.HeroRepository  .Add(hero);                

                // Create token:
                var tokenBuilder = new HeroTokenBuilder(this.Configuration, hero);

                this.TokenDirector.CreateToken(tokenBuilder);

                return new OkObjectResult(new { Token = tokenBuilder.Build() }) as IActionResult;

            });            
        }
        public Task<IActionResult> CreateHeroHitAsync   (CreateCommand<CommandHandler, CreateHitPayload > command)
        {
            return Task.Run(() =>
            {
                var payload = command.Payload;
                var hero    = this.Heroes.FindById(payload.SourceId);

                if (hero   is null) return new BadRequestObjectResult(new {
                    Message = "Hero not found."
                }) as IActionResult;


                var dragon = this.Dragons.FindById(payload.TargetId);

                if (dragon is null) return new BadRequestObjectResult(new {
                    Message = "Dragon not found."
                }) as IActionResult;


                var hit = hero.Hit(dragon);
                
                this.HitRepository.Add(hit);
                this.DragonRepository.Update(dragon);


                return new OkObjectResult(new { Hit = hit, Dragon = dragon }) as IActionResult;
            });            
        }
        public Task<IActionResult> CreateDragonAsync    (CreateCommand<CommandHandler>                    command)
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

        public Task<IActionResult> ReadHeroByNameAsync  (ReadCommand<CommandHandler, ReadHeroByNamePayload  > command)
        {
            return Task.Run(() =>
            {
                // Check if hero name format is valid:
                var payload      = command.Payload;
                var heroName     = payload.ViewModel.Name ?? String.Empty;
                var isNameValid  = !(heroName.IsNull() || heroName.IsEmpty() || heroName.IsWhiteSpace());
                var errorMessage = "Hero with specified name doesn't exist.";

                if (!isNameValid) return new BadRequestObjectResult(new { Message = errorMessage }) as IActionResult;

                // Check if hero exists:
                var hero = this.Heroes.FindByName(heroName, SearchType.Equal).Include(h => h.Weapon).FirstOrDefault();

                if (hero is null) return new BadRequestObjectResult(new { Message = errorMessage }) as IActionResult;

                // Create hero token:
                var builder  = new HeroTokenBuilder(this.Configuration, hero);

                this.TokenDirector.CreateToken(builder);

                var token    = builder.Build();

                // Create hero view:
                var heroView = ViewModelFactory.Create(s => s.HeroViewModel(hero));

                return new OkObjectResult(new { Token = token, Hero  = heroView }) as IActionResult;
            });            
        }
        public Task<IActionResult> ReadHeroesAsync      (ReadCommand<CommandHandler, ReadHeroesPayload      > command)
        {
            return Task.Run(() =>
            {
                var payload = command.Payload;
                var view    = this.Heroes
                                .FilterBy       (payload.FilterCode)
                                .OrderBy        (payload.OrderingCode, payload.OrderCode)
                                .ToHeroModelView(payload.Page.Number , payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });            
        }
        public Task<IActionResult> ReadHeroHitsAsync    (ReadCommand<CommandHandler, ReadHeroHitsPayload    > command)
        {
            return Task.Run(() =>
            {
                var payload = command.Payload;
                var view    = this.Hits
                                .SelectHeroHitsById (payload.HeroId    )
                                .FilterBy           (payload.FilterCode)
                                .OrderBy            (payload.OrderingCode, payload.OrderCode)
                                .ToHeroHitsModelView(payload.Page.Number , payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });            
        }
        public Task<IActionResult> ReadHeroesByNameAsync(ReadCommand<CommandHandler, ReadHeroesByNamePayload> command)
        {
            return Task.Run(() =>
            {
                var payload = command.Payload;
          
                var view    = this.Heroes
                                .FindByName     (payload.Name ?? String.Empty, payload.SearchType)
                                .OrderBy        (payload.OrderingCode, payload.OrderCode)
                                .FilterBy       (payload.FilterCode)
                                .ToHeroModelView(payload.Page.Number, payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });            
        }
        public Task<IActionResult> ReadDragonsAsync     (ReadCommand<CommandHandler, ReadDragonsPayload     > command)
        {
            return Task.Run(() =>
            {
                var payload = command.Payload;
                var view    = this.Dragons
                                .FilterBy         (payload.FilterCode)
                                .OrderBy          (payload.OrderingCode, payload.OrderCode)
                                .ToDragonModelView(payload.Page.Number , payload.Page.Size);

                return new OkObjectResult(view) as IActionResult;
            });
        }
        public Task<IActionResult> ReadDragonByIdAsync  (ReadCommand<CommandHandler, ReadDragonByIdPayload  > command)
        {
            return Task.Run(() => 
            {
                var payload = command.Payload;
                var dragon  = this.Dragons.FindById(payload.Id);

                if (dragon is null) return new BadRequestObjectResult(new {
                    Message = "Dragon not found."
                }) as IActionResult;
                
                return new OkObjectResult(new { Dragon = dragon }) as IActionResult;
            });                                 
        }

        #endregion
    }
}
