using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels.Characters.Dragons
{
    public class DragonViewModel : ViewModel
    {
        public int      Id      { get; set; }
        public string   Name    { get; set; }
        public short    Health  { get; set; }
        public DateTime Created { get; set; }               
    }   
}
