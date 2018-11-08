using ServerApp.Data.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadDragonsPayload : ReadPayload<DragonsFilter, DragonsOrdering>
    {
        public ReadDragonsPayload(DragonsFilter filterCode, DragonsOrdering orderingCode, OrderType orderCode, int pageNumber, int pageSize) : base(filterCode, orderingCode, orderCode, pageNumber, pageSize)
        {
        }

        public ReadDragonsPayload(int filterCode, int orderingCode, int orderType, int pageNumber, int pageSize) : base(filterCode, orderingCode, orderType, pageNumber, pageSize)
        {
        }

        public ReadDragonsPayload(string filterCodeName, string orderingCode, string orderType, int pageNumbe, int pageSize) : base(filterCodeName, orderingCode, orderType, pageNumbe, pageSize)
        {
        }
    }
}
