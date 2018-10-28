using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class GameDbContext : DbContext
    {
        DbSet<Dragon> Dragons { get; set; }
        DbSet<Hero>   Heroes  { get; set; }
        DbSet<Hit>    Hits    { get; set; }



        public GameDbContext(DbContextOptions options) : base(options)
        {
            if (options == null) { throw new ArgumentNullException(nameof(options)); }
        }

        protected GameDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DragonConfiguration())
                        .ApplyConfiguration(new HeroConfiguration  ())
                        .ApplyConfiguration(new WeaponConfiguration())
                        .ApplyConfiguration(new HeroConfiguration  ());
        }
    }
}
