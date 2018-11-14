using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class WeaponRepository : Repository<Weapon>
    {
        public WeaponRepository(GameDbContext context) : base(context)
        {
        }
    }
}
