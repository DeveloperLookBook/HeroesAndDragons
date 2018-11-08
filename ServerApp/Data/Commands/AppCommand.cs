using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Handlers;
using ServerApp.Data.Repositories;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public abstract class AppCommand<THandler, TPayload> : IAppCommand<TPayload>
        where THandler : class
    {
        public  CommandType      Code    { get; }
        private THandler         Handler { get; }
        public  TPayload         Payload { get; }

        object       IAppCommand.Payload => this.Payload;

        private Func<AppCommand<THandler, TPayload>, THandler, Task<IActionResult>> Resiver { get; }


        public AppCommand(
            CommandType code, 
            THandler    handler,
            Func<IAppCommand<TPayload>, THandler, Task<IActionResult>> resiver, 
            TPayload    payload)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            if (resiver is null) throw new ArgumentNullException(nameof(resiver));
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            this.Code    = code;
            this.Handler = handler;
            this.Payload = payload;
            this.Resiver = resiver;
        }


        public Task<IActionResult> Execute<TReturn>() => this.Resiver(this, this.Handler);
    }
}
