using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public class CreateCommand<THandler, TPayload> : AppCommand<THandler, TPayload>
        where THandler : class
    {
        public CreateCommand(
            CommandType code, 
            THandler    handler, 
            Func<CreateCommand<THandler, TPayload>, THandler, Task<IActionResult>> resiver, 
            TPayload    payload)
            
            : base(code, handler, resiver as Func<IAppCommand<TPayload>, THandler, Task<IActionResult>>, payload)
        {
        }
    }
}
