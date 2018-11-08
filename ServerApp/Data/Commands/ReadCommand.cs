using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public class ReadCommand<THandler, TPayload> : AppCommand<THandler, TPayload>
        where THandler : class
    {
        public ReadCommand(
            CommandType code, 
            THandler    handler, 
            Func<ReadCommand<THandler, TPayload>, THandler, Task<IActionResult>> resiver, 
            TPayload    payload) 

            : base(code, handler, resiver as Func<IAppCommand<TPayload>, THandler, Task<IActionResult>>, payload)
        {
        }
    }
}
