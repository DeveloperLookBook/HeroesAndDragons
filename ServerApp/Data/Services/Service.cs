using ServerApp.Data.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Services
{
    public abstract class Service
    {
        protected Mediator Mediator { get; }


        protected Service(Mediator mediator)
        {
            this.Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
