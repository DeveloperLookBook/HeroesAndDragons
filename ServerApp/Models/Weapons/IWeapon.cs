using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public interface IWeapon : IModel<int>
    {
        short Strength { get; }
    }
}
