using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadDragonByIdPayload
    {
        public int Id { get; }

        public ReadDragonByIdPayload(int id)
        {
            this.Id = id;
        }
    }
}
