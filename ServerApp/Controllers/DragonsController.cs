using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Commands;
using ServerApp.Data.Commands.Payloads;
using ServerApp.Data.Services.Helpers;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DragonsController : ControllerBase
    {
        private CommandFactory CommandFactory { get; }


        public DragonsController(CommandFactory commandFactory) => this.CommandFactory = commandFactory;


        // GET: api/Heroes/search-filter:{filterBy}/order-by:{orderBy}/order:{order}/page-number:{pageNumber?:int}/page-size:{pageSize?:int}
        [Authorize]
        [HttpGet("search-filter:{filterBy}/order-by:{orderBy}/order:{order}/page-number:{pageNumber:int}/page-size:{pageSize:int}")]
        public Task<IActionResult> GetDragons(string filterBy, string orderBy, string order, int pageNumber = 1, int pageSize = 15)
        {
            if (!Enum.TryParse(filterBy, true, out DragonsFilter   filterCode  )) { filterCode   = 0; }
            if (!Enum.TryParse(orderBy , true, out DragonsOrdering orderingCode)) { orderingCode = 0; }
            if (!Enum.TryParse(order   , true, out OrderType       orderCode   )) { orderCode    = 0; }


            return this.CommandFactory.Create(s => s.ReadDragons(new ReadDragonsPayload(
                filterCode,
                orderingCode,
                orderCode,
                pageNumber,
                pageSize))).Execute();
        }

        // Post: api/create
        [Authorize]
        [HttpPost("create")]
        public Task<IActionResult> CreateDragon()
        {
            return this.CommandFactory.Create(s => s.CreateDragon()).Execute();
        }
    }
}
