using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class HitsRepository : Repository<Hit>
    {
        public HitsRepository(GameDbContext context) : base(context)
        {
        }
    }
}
