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

namespace ServerApp.Data.Handlers
{
    public class CommandHandler
    {
        IRepository<IHero  > HeroRepository   { get; }
        IRepository<IDragon> DragonRepository { get; }
        IRepository<IHit   > HitRepository    { get; }


        public CommandHandler(IRepositoryFactory factory)
        {
            this.HeroRepository   = factory.Create(s => s.Heroes ());
            this.DragonRepository = factory.Create(s => s.Dragons());
            this.HitRepository    = factory.Create(s => s.Hits   ());
        }

        #region HANDLER: CREATE HERO HIT

        public Task<IActionResult> HandlAsync(CreateCommand<>)

        #endregion


        #region HANDLER: READ HEROES COMMAND -----------------------------------------------------

        public Task<IActionResult> HandleAsync(ReadCommand<CommandHandler, ReadHeroesPayload> command)
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

        #endregion

        #region HANDLER: READ DRAGONS COMMAND ----------------------------------------------------

        public Task<IActionResult> HandleAsync(ReadCommand<CommandHandler, ReadDragonsPayload> command)
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

        #endregion

        #region HANDLER: READ HERO HITS COMMAND --------------------------------------------------

        public Task<IActionResult> HandleAsync(ReadCommand<CommandHandler, ReadHeroHitsPayload> command)
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

        #endregion
    }
}
