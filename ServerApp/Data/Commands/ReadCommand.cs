using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public delegate Task<IActionResult> OnReadCommandExecute<THandler>(
        ReadCommand<THandler> command, THandler handler)
        where THandler : class;

    public class ReadCommand<THandler> : AppCommand<THandler>
        where THandler : class
    {
        private OnReadCommandExecute<THandler> OnExecute { get; }


        public ReadCommand(
            CommandType                    code, 
            THandler                       handler,
            OnReadCommandExecute<THandler> onExecute) 
            
            : base(code, handler)
        {
            this.OnExecute = onExecute;
        }


        public override Task<IActionResult> Execute() => this.OnExecute(this, this.Handler);
    }



    public delegate Task<IActionResult> OnReadCommandExecute<THandler, TPayload>(
       ReadCommand<THandler, TPayload> command, THandler handler)
       where THandler : class;


    public class ReadCommand<THandler, TPayload> : AppCommand<THandler, TPayload>, ICreateCommand
        where THandler : class
    {
        private OnReadCommandExecute<THandler, TPayload> OnExecute { get; }


        public ReadCommand(
            CommandType                              code,
            THandler                                 handler,
            OnReadCommandExecute<THandler, TPayload> onExcecute,
            TPayload payload)

            : base(code, handler, payload)
        {
            this.OnExecute = onExcecute;
        }


        public override Task<IActionResult> Execute() => this.OnExecute(this, this.Handler);
    }
}
