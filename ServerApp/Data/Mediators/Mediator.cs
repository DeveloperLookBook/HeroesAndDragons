using Microsoft.AspNetCore.Mvc;
using ServerApp.Data.Commands;
using ServerApp.Data.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Mediators
{
    abstract public class Mediator
    {
        abstract public void Execute<TMessage, THandler>(TMessage message, THandler handler) where THandler : Service;
    }
}
