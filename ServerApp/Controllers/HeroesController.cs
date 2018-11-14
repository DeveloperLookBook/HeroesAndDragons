using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Commands;
using ServerApp.Data.Commands.Payloads;
using ServerApp.Data.Repositories;
using ServerApp.Data.Services.Helpers;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private CommandFactory CommandFactory { get; }


        public HeroesController(CommandFactory commandFactory) => this.CommandFactory = commandFactory;


        // GET: api/Heroes
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Heroes/search-type:{}/search-name:{}/search-filter:{}/result-ordered-by:{}/result-order:{}/result-page-number:{}/result-page-size{}
        [HttpGet("search-type:{searchType:SearchType}"             +
                 "search-name:{name:string}"                       +
                 "search-filter:{filterCode:HeroesFilter}"         +
                 "result-ordered-by:{orderingCode:HeroesOrdering}" +
                 "result-order:{orderCode:OrderType}"              +
                 "result-page-number:{pageNumber:int}"             +
                 "result-page-size:{pageSize:int}")]
        [Authorize]
        public Task<IActionResult> GetHeroesByName(
            SearchType     searchType, 
            string         name, 
            HeroesFilter   filterCode, 
            HeroesOrdering orderingCode,
            OrderType      orderCode,
            int            pageNumber,
            int            pageSize)
        {
            return this.CommandFactory.Create(s => s.ReadHeroesByName(new ReadHeroesByNamePayload(
                searchType,
                name,
                filterCode,
                orderingCode,
                orderCode,
                pageNumber,
                pageSize))).Execute();
        }

        // GET: api/Heroes/search-filter:{}/result-ordered-by:{}/result-order:{}/result-page-number:{}/result-page-size{}
        [HttpGet("search-filter:{filterCode:HeroesFilter}"         +
                 "result-ordered-by:{orderingCode:HeroesOrdering}" +
                 "result-order:{orderCode:OrderType}"              +
                 "result-page-number:{pageNumber:int}"             +
                 "result-page-size:{pageSize:int}")]
        [Authorize]
        public Task<IActionResult> GetHeroes(
            HeroesFilter   filterCode, 
            HeroesOrdering orderingCode,
            OrderType      orderCode,
            int            pageNumber,
            int            pageSize)
        {
            return this.CommandFactory.Create(s => s.ReadHeroes(new ReadHeroesPayload(
                filterCode,
                orderingCode,
                orderCode,
                pageNumber,
                pageSize))).Execute();
        }        
    }
}
