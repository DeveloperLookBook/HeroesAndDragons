using ServerApp.Models.Characters.Dragons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class DragonsRepository : Repository<Dragon>
    {
        public DragonsRepository(GameDbContext context) : base(context)
        {
        }
    }
}
