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

            public CreateCommand<CommandHandler, >

            #endregion

            #region READ COMMANDS ---------------------------------------------------------------------------

            public ReadCommand<CommandHandler, ReadHeroesPayload  > ReadHeroes  (ReadHeroesPayload   payload)
            {
                return new ReadCommand<CommandHandler, ReadHeroesPayload>(
                    CommandType.ReadHeroes, 
                    CommandHandler,
                    (command, handler) => handler.HandleAsync(command),
                    payload);
            }
            public ReadCommand<CommandHandler, ReadDragonsPayload > ReadDragons (ReadDragonsPayload  payload)
            {
                return new ReadCommand<CommandHandler, ReadDragonsPayload>(
                    CommandType.ReadDragons,
                    CommandHandler,
                    (command, handler) => handler.HandleAsync(command),
                    payload);
            }
            public ReadCommand<CommandHandler, ReadHeroHitsPayload> ReadHeroHits(ReadHeroHitsPayload payload)
            {
                return new ReadCommand<CommandHandler, ReadHeroHitsPayload>(
                    CommandType.ReadHits,
                    CommandHandler,
                    (command, handler) => handler.HandleAsync(command),
                    payload);
            }

            #endregion
        }


        static private CommandCreator InstanceCreator { get; }


        static public TCommand Create<TCommand>(CommandFactorySelectorFunc<TCommand> selector) 
            where TCommand : IAppCommand
        {
            return selector(InstanceCreator);
        }
    }
}
