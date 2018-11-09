using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Data.Commands
{
    public interface ICreateCommand
    {
        Task<IActionResult> Execute();
    }
}