using ServerApp.Models.Characters.Dragons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class DragonsRepository : Repository<IDragon>, IDragonsRepository
    {
        public DragonsRepository(GameDbContext context) : base(context)
        {
        }
    }
}
