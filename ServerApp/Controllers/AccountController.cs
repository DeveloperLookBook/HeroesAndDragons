using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Commands;
using ServerApp.Data.Commands.Payloads;
using ServerApp.ViewModels.Characters.Heroes;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private CommandFactory CommandFactory { get; }


        public AccountController(CommandFactory commandFactory) => this.CommandFactory = commandFactory;


        // POST: api/Account/Signup
        [HttpPost("Signup")]
        public Task<IActionResult> SignupAsync([FromBody] SignupHeroViewModel viewModel)
        {
            return CommandFactory
                       .Create(s => s.CreateHero(new CreateHeroPayload(viewModel)))
                       .Execute();
        }

        // POST: api/Account/Signin
        [HttpPost("Signin")]
        public Task<IActionResult> Signin([FromBody] SigninHeroViewModel viewModel)
        {
            return CommandFactory
                       .Create(s => s.ReadHeroByName(new ReadHeroByNamePayload(viewModel)))
                       .Execute();
        }        
    }
}
