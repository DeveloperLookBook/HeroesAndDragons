using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using ServerApp.ViewModels.Heroes;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IGameEngine GameEngine { get; }

        public AccountController(IGameEngine gameEngine) => this.GameEngine = gameEngine;

        [AllowAnonymous]
        [HttpPost("signin")]
        public Task<IActionResult> Signin([FromBody] SignupHeroViewModel hero) => this.GameEngine.Signup(hero);

        public IActionResult Test()
        {
            return this.BadRequest();
        }
    }
}