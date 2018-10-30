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
        public DbSet<Dragon> Dragons { get; set; }
        public DbSet<Hero>   Heroes  { get; set; }
        public DbSet<Hit>    Hits    { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

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

            this.SetModelsConfigurations(modelBuilder);
            this.SetModelsSeeds         (modelBuilder);
        }

        protected void SetModelsConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DragonConfiguration())
                        .ApplyConfiguration(new HeroConfiguration  ())
                        .ApplyConfiguration(new WeaponConfiguration())
                        .ApplyConfiguration(new HeroConfiguration  ());
        }

        protected void SetModelsSeeds(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeaponSeeds());
        }
    }
}
