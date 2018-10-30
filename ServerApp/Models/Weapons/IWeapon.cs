using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public interface IWeapon : IModel<int>
    {
        string Name     { get; }
        short  Strength { get; }
    }
}
