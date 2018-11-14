using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class HeroesRepository : Repository<Hero>
    {
        public HeroesRepository(GameDbContext context) : base(context)
        {
        }
    }
}
