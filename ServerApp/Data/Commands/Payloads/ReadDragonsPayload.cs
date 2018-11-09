using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadDragonsPayload : ReadCommandPayload<DragonsFilter, DragonsOrdering>
    {
        public ReadDragonsPayload(
            DragonsFilter   filterCode, 
            DragonsOrdering orderingCode, 
            OrderType       orderCode, 
            int             pageNumber, 
            int             pageSize) 
            
            : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
        }
    }
}
