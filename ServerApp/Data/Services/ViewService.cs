using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Data.Mediators;
using ServerApp.Data.Repositories;
using ServerApp.Models;
using ServerApp.Paginations;

namespace ServerApp.Data.Services
{
    public class ViewService : Service
    {
        public ViewService(IRepository<IModel> repository, Mediator mediator) : base(mediator)
        {
        }

        public IView Create()
        {

        }
    }
}
