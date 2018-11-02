using ServerApp.Data.UnitOfWorks;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public abstract class Command : ICommand
    {
        protected IGameContext Context { get; }

        protected Command(IGameContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public abstract void Execute();
    }
}
