using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands.Payloads
{
    public class CreateHeroPayload : CreateCommandPayload
    {
        public SignupHeroViewModel ViewModel { get; }

        public CreateHeroPayload(SignupHeroViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }        
    }
}
