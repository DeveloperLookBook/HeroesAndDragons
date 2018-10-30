using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class HeroesRepository : Repository<IHero>, IHeroesRepository
    {
        public HeroesRepository(GameDbContext context) : base(context)
        {
        }
    }
}
