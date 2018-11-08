using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Data.Mediators;

namespace ServerApp.Data.Services
{
    public class ContextService : Service
    {
        public ContextService(Mediator mediator) : base(mediator)
        {
        }
    }
}
