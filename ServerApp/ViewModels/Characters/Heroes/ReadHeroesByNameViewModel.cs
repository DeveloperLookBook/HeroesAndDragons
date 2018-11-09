using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels.Characters.Heroes
{
    public class ReadHeroesByNameViewModel : ViewModel
    {
        public string SearchType { get; set; }
        public bool   IgnroeCase { get; set; }
        public string Name       { get; set; }       
    }
}
