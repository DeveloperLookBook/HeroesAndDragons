using Microsoft.Extensions.Configuration;
using ServerApp.Data.Services;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class ReadHeroByNamePayload
    {
        public SigninHeroViewModel ViewModel { get; }

        public ReadHeroByNamePayload(SigninHeroViewModel ViewModel)
        {
            this.ViewModel = ViewModel ?? throw new ArgumentNullException(nameof(ViewModel));
        }
    }
}
