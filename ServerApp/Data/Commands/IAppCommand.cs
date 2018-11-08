using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Data.Commands
{    
    public interface IAppCommand
    {
        CommandType Code    { get; }
        object      Payload { get; }

        Task<IActionResult> Execute<TReturn>();
    }

    public interface IAppCommand<TPayload> : IAppCommand
    {
        new TPayload Payload { get; }
    }
}