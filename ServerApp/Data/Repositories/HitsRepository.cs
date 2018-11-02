using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Hits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class HitsRepository : Repository<IHit>
    {
        public HitsRepository(GameDbContext context) : base(context)
        {
        }
    }
}
