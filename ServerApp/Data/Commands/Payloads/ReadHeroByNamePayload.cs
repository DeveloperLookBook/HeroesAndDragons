using Microsoft.Extensions.Configuration;
using ServerApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroByNamePayload
    {
        public string Name { get; }

        public ReadHeroByNamePayload(string name)
        {
            this.Name = name ?? String.Empty;
        }
    }
}
