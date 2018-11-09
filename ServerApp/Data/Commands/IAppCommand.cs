using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Data.Commands
{    
    public interface IAppCommand
    {
        CommandType Code { get; }

        Task<IActionResult> Execute();
    }    

    public interface IAppCommand<TPayload> : IAppCommand
    {
        TPayload Payload { get; }
    }
}