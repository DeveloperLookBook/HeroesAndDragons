using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public class WeaponViewModel : ViewModel
    {
        public int    Id       { get; set; }
        public string Name     { get; set; }
        public short  Strength { get; set; }      
    }
}
