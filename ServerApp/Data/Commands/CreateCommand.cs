using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public delegate Task<IActionResult> OnCreateCommandExecute<THandler>(
        CreateCommand<THandler> command, THandler handler)
        where THandler : class;


    public class CreateCommand<THandler> : AppCommand<THandler>, ICreateCommand 
        where THandler : class
    {
        private OnCreateCommandExecute<THandler> OnExecute { get; }

        public CreateCommand(
            CommandType                      code, 
            THandler                         handler,
            OnCreateCommandExecute<THandler> onExcecute)             
            : base(code, handler)
        {
            this.OnExecute = onExcecute;
        }

        public override Task<IActionResult> Execute() => this.OnExecute(this, this.Handler);
    }



    public delegate Task<IActionResult> OnCreateCommandExecute<THandler, TPayload>(
       CreateCommand<THandler, TPayload> command, THandler handler)
       where THandler : class;


    public class CreateCommand<THandler, TPayload> : AppCommand<THandler, TPayload>, ICreateCommand
        where THandler : class
    {
        private OnCreateCommandExecute<THandler, TPayload> OnExecute { get; }

        public CreateCommand(
            CommandType                                code, 
            THandler                                   handler,
            OnCreateCommandExecute<THandler, TPayload> onExcecute,
            TPayload                                   payload) 
            : base(code, handler, payload)
        {
            this.OnExecute = onExcecute;
        }

        public override Task<IActionResult> Execute() => this.OnExecute(this, this.Handler);
    }
}
