using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using ServerApp.Models.Weapons.Axes;
using ServerApp.Models.Weapons.Crossbows;
using ServerApp.Models.Weapons.Knives;
using ServerApp.Models.Weapons.Rapiers;
using ServerApp.Models.Weapons.Shields;
using ServerApp.Models.Weapons.Swords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class GameDbContext : DbContext
    {
        public DbSet<Weapon>   Weapons   { get; set; }
        public DbSet<Axe>      Axes      { get; set; }
        public DbSet<Crossbow> Crossbows { get; set; }
        public DbSet<Knive>    Knives    { get; set; }
        public DbSet<Rapier>   Rapiers   { get; set; }
        public DbSet<Shield>   Shields   { get; set; }
        public DbSet<Sword>    Swords    { get; set; }

        public DbSet<Hero>     Heroes    { get; set; }
        public DbSet<Dragon>   Dragons   { get; set; }
        public DbSet<Hit>      Hits      { get; set; }


        public GameDbContext(DbContextOptions options) : base(options)
        {
            if (options is null) { throw new ArgumentNullException(nameof(options)); }
        }


        protected override void OnConfiguring  (DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hero>().HasOne(h => h.Weapon);

            modelBuilder.Entity<Hit> ().HasOne(h => h.Source);
            modelBuilder.Entity<Hit> ().HasOne(h => h.Target);
            modelBuilder.Entity<Hit> ().HasOne(h => h.Weapon);

            modelBuilder.Entity<Axe>     ().HasBaseType<Weapon>();
            modelBuilder.Entity<Crossbow>().HasBaseType<Weapon>();
            modelBuilder.Entity<Knive>   ().HasBaseType<Weapon>();
            modelBuilder.Entity<Rapier>  ().HasBaseType<Weapon>();
            modelBuilder.Entity<Shield>  ().HasBaseType<Weapon>();
            modelBuilder.Entity<Sword>   ().HasBaseType<Weapon>();

            this.SetModelsConfigurations(modelBuilder);
            this.SetModelsSeeds         (modelBuilder);
        }


        protected void SetModelsConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DragonConfiguration())
                        .ApplyConfiguration(new HeroConfiguration  ())
                        .ApplyConfiguration(new WeaponConfiguration())
                        .ApplyConfiguration(new HitConfiguration   ());

        }
        protected void SetModelsSeeds         (ModelBuilder modelBuilder)
        {
        }
    }
}
