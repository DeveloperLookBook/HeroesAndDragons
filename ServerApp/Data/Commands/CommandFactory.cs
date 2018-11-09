using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Commands.Payloads;
using ServerApp.Data.Handlers;
using ServerApp.Data.Repositories;
using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public delegate TCommand CommandFactorySelectorFunc<TCommand>(ICommandCreator creator)
        where TCommand : IAppCommand;

    public static class CommandFactory
    {
        #region COMMAND CREATOR

        private class CommandCreator : ICommandCreator
        {
            private RepositoryFactory RepositoryFactory { get; }
            private CommandHandler    CommandHandler    { get; }


            public CommandCreator(RepositoryFactory factory)
            {
                this.RepositoryFactory = factory ?? throw new ArgumentNullException(nameof(factory));
                this.CommandHandler    = new CommandHandler(this.RepositoryFactory);
            }


            #region CREATE COMMANDS -------------------------------------------------------------------------

            public CreateCommand<CommandHandler, CreateHeroPayload> CreateHero  (CreateHeroPayload payload)
            {
                return new CreateCommand<CommandHandler, CreateHeroPayload>(
                    CommandType.CreateHero,
                    CommandHandler,
                    (command, handler) => handler.CreateHeroAsync(command),
                    payload);
            }
            public CreateCommand<CommandHandler, CreateHitPayload > CreateHit   (CreateHitPayload  payload)
            {
                return new CreateCommand<CommandHandler, CreateHitPayload>(
                    CommandType.CreateHit,
                    CommandHandler,
                    (command, handler) => handler.CreateHeroHitAsync(command),
                    payload);
            }
            public CreateCommand<CommandHandler>                    CreateDragon()
            {
                return new CreateCommand<CommandHandler>(
                    CommandType.CreateDragon,
                    CommandHandler,
                    (command, handler) => handler.CreateDragonAsync(command));
            }

            #endregion

            #region READ COMMANDS ---------------------------------------------------------------------------

            public ReadCommand<CommandHandler, ReadHeroByNamePayload  > ReadHeroByNameAndPassword
            public ReadCommand<CommandHandler, ReadHeroesPayload      > ReadHeroes      (ReadHeroesPayload       payload)
            {
                return new ReadCommand<CommandHandler, ReadHeroesPayload>(
                    CommandType.ReadHeroes, 
                    CommandHandler,
                    (command, handler) => handler.ReadHeroesAsync(command),
                    payload);
            }
            public ReadCommand<CommandHandler, ReadHeroHitsPayload    > ReadHeroHits    (ReadHeroHitsPayload     payload)
            {
                return new ReadCommand<CommandHandler, ReadHeroHitsPayload>(
                    CommandType.ReadHits,
                    CommandHandler,
                    (command, handler) => handler.ReadHeroHitsAsync(command),
                    payload);
            }
            public ReadCommand<CommandHandler, ReadHeroesByNamePayload> ReadHeroesByName(ReadHeroesByNamePayload payload)
            {
                return new ReadCommand<CommandHandler, ReadHeroesByNamePayload>(
                    CommandType.ReadHeroesByName,
                    CommandHandler,
                    (command, handler) => handler.ReadHeroesByNameAsync(command),
                    payload);
            }
            public ReadCommand<CommandHandler, ReadDragonsPayload     > ReadDragons     (ReadDragonsPayload      payload)
            {
                return new ReadCommand<CommandHandler, ReadDragonsPayload>(
                    CommandType.ReadDragons,
                    CommandHandler,
                    (command, handler) => handler.ReadDragonsAsync(command),
                    payload);
            }
            public ReadCommand<CommandHandler, ReadDragonByIdPayload  > ReadDragonById  (ReadDragonByIdPayload   payload)
            {
                return new ReadCommand<CommandHandler, ReadDragonByIdPayload>(
                    CommandType.ReadDragonById,
                    CommandHandler,
                    (command, handler) => handler.ReadDragonByIdAsync(command),
                    payload);
            }

            #endregion
        }

        #endregion


        static private CommandCreator InstanceCreator { get; }


        static public TCommand Create<TCommand>(CommandFactorySelectorFunc<TCommand> selector) 
            where TCommand : IAppCommand
        {
            return selector(InstanceCreator);
        }
    }
}
