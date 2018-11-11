using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Receivers;
using ServerApp.Data.Repositories;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public abstract class AppCommand<THandler> : IAppCommand 
        where THandler : class
    {
        public    CommandType Code      { get; }
        protected THandler    Handler   { get; }


        public AppCommand(CommandType code, THandler handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));

            this.Code    = code;
            this.Handler = handler;
        }


        abstract public Task<IActionResult> Execute();
    }


    public abstract class AppCommand<THandler, TPayload> : AppCommand<THandler>, IAppCommand<TPayload>        
        where THandler : class
    {
        public  TPayload Payload { get; }

        public AppCommand(CommandType code, THandler handler, TPayload payload) 

            : base(code, handler)
        {
            this.Payload = payload;
        }
    }
}
