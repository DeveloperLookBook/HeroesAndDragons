using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using ServerApp.Models.Characters;
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
            base.OnModelCreating        (modelBuilder);
            this.SetModelsConfigurations(modelBuilder);
            this.SetModelsSeed          (modelBuilder);
        }

        protected void SetModelsConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DragonConfiguration())
                        .ApplyConfiguration(new HeroConfiguration  ())
                        .ApplyConfiguration(new WeaponConfiguration())
                        .ApplyConfiguration(new HitConfiguration   ());

            // Weapon inheritance configurations:
            modelBuilder.Entity<Axe>     ().HasBaseType<Weapon>();
            modelBuilder.Entity<Crossbow>().HasBaseType<Weapon>();
            modelBuilder.Entity<Knive>   ().HasBaseType<Weapon>();
            modelBuilder.Entity<Rapier>  ().HasBaseType<Weapon>();
            modelBuilder.Entity<Shield>  ().HasBaseType<Weapon>();
            modelBuilder.Entity<Sword>   ().HasBaseType<Weapon>();

            // Character inheritance configurations:
            modelBuilder.Entity<Hero>  ().HasBaseType<Character>();
            modelBuilder.Entity<Dragon>().HasBaseType<Character>();

            // Weapon relationship configurations:
            modelBuilder.Entity<Hit> ().HasOne(h => h.Source);
            modelBuilder.Entity<Hit> ().HasOne(h => h.Target);
            modelBuilder.Entity<Hit> ().HasOne(h => h.Weapon);    
        } 
        
        protected void SetModelsSeed(ModelBuilder modelBuilder)
        {
            // Weapon seed:

            modelBuilder.Entity<Axe>().HasData(
                new { Id = 1 , Name = "Axe"     , Strength = (short)15, Created = DateTime.Now },
                new { Id = 2 , Name = "Axe"     , Strength = (short)15, Created = DateTime.Now },
                new { Id = 3 , Name = "Axe"     , Strength = (short)15, Created = DateTime.Now });

            modelBuilder.Entity<Crossbow>().HasData(
                new { Id = 4 , Name = "Crossbow", Strength = (short)20, Created = DateTime.Now },
                new { Id = 5 , Name = "Crossbow", Strength = (short)20, Created = DateTime.Now },
                new { Id = 6 , Name = "Crossbow", Strength = (short)20, Created = DateTime.Now });

            modelBuilder.Entity<Knive>().HasData(
                new { Id = 7 , Name = "Knive"   , Strength = (short)8 , Created = DateTime.Now },
                new { Id = 8 , Name = "Knive"   , Strength = (short)8 , Created = DateTime.Now },
                new { Id = 9 , Name = "Knive"   , Strength = (short)8 , Created = DateTime.Now });

            modelBuilder.Entity<Rapier>().HasData(
                new { Id = 10, Name = "Rapier"  , Strength = (short)12, Created = DateTime.Now },
                new { Id = 11, Name = "Rapier"  , Strength = (short)12, Created = DateTime.Now },
                new { Id = 12, Name = "Rapier"  , Strength = (short)12, Created = DateTime.Now });

            modelBuilder.Entity<Shield>().HasData(
                new { Id = 13, Name = "Shield"  , Strength = (short)15, Created = DateTime.Now },
                new { Id = 14, Name = "Shield"  , Strength = (short)15, Created = DateTime.Now },
                new { Id = 15, Name = "Shield"  , Strength = (short)15, Created = DateTime.Now });

            modelBuilder.Entity<Sword>().HasData(
                new { Id = 16, Name = "Sword"   , Strength = (short)20, Created = DateTime.Now },
                new { Id = 17, Name = "Sword"   , Strength = (short)20, Created = DateTime.Now },
                new { Id = 18, Name = "Sword"   , Strength = (short)20, Created = DateTime.Now });           

            // Hero seed:

            modelBuilder.Entity<Hero>().HasData(
                new { Id = 1,  Name = "Hero1" , WeaponId = 1 , Created = DateTime.Now },
                new { Id = 2,  Name = "Hero2" , WeaponId = 2 , Created = DateTime.Now },
                new { Id = 3,  Name = "Hero3" , WeaponId = 3 , Created = DateTime.Now },
                new { Id = 4,  Name = "Hero4" , WeaponId = 4 , Created = DateTime.Now },
                new { Id = 5,  Name = "Hero5" , WeaponId = 5 , Created = DateTime.Now },
                new { Id = 6,  Name = "Hero6" , WeaponId = 6 , Created = DateTime.Now },
                new { Id = 7,  Name = "Hero7" , WeaponId = 7 , Created = DateTime.Now },
                new { Id = 8,  Name = "Hero8" , WeaponId = 8 , Created = DateTime.Now },
                new { Id = 9,  Name = "Hero9" , WeaponId = 9 , Created = DateTime.Now },
                new { Id = 10, Name = "Hero10", WeaponId = 10, Created = DateTime.Now },
                new { Id = 11, Name = "Hero11", WeaponId = 11, Created = DateTime.Now },
                new { Id = 12, Name = "Hero12", WeaponId = 12, Created = DateTime.Now },
                new { Id = 13, Name = "Hero13", WeaponId = 13, Created = DateTime.Now },
                new { Id = 14, Name = "Hero14", WeaponId = 14, Created = DateTime.Now },
                new { Id = 15, Name = "Hero15", WeaponId = 15, Created = DateTime.Now },
                new { Id = 16, Name = "Hero16", WeaponId = 16, Created = DateTime.Now },
                new { Id = 17, Name = "Hero17", WeaponId = 17, Created = DateTime.Now },
                new { Id = 18, Name = "Hero18", WeaponId = 18, Created = DateTime.Now });

            // Dragon seed:

            modelBuilder.Entity<Dragon>().HasData(
                new { Id = 19, Name = "Dragon1" , Health = (short)80 , Created = DateTime.Now },
                new { Id = 20, Name = "Dragon2" , Health = (short)85 , Created = DateTime.Now },
                new { Id = 21, Name = "Dragon3" , Health = (short)90 , Created = DateTime.Now },
                new { Id = 22, Name = "Dragon4" , Health = (short)95 , Created = DateTime.Now },
                new { Id = 23, Name = "Dragon5" , Health = (short)100, Created = DateTime.Now },
                new { Id = 24, Name = "Dragon6" , Health = (short)93 , Created = DateTime.Now },
                new { Id = 25, Name = "Dragon7" , Health = (short)87 , Created = DateTime.Now },
                new { Id = 26, Name = "Dragon8" , Health = (short)82 , Created = DateTime.Now },
                new { Id = 27, Name = "Dragon9" , Health = (short)86 , Created = DateTime.Now },
                new { Id = 28, Name = "Dragon10", Health = (short)89 , Created = DateTime.Now },
                new { Id = 29, Name = "Dragon11", Health = (short)92 , Created = DateTime.Now },
                new { Id = 30, Name = "Dragon12", Health = (short)98 , Created = DateTime.Now },
                new { Id = 31, Name = "Dragon13", Health = (short)91 , Created = DateTime.Now },
                new { Id = 32, Name = "Dragon14", Health = (short)99 , Created = DateTime.Now },
                new { Id = 33, Name = "Dragon15", Health = (short)91 , Created = DateTime.Now },
                new { Id = 34, Name = "Dragon16", Health = (short)87 , Created = DateTime.Now },
                new { Id = 35, Name = "Dragon17", Health = (short)80 , Created = DateTime.Now },
                new { Id = 36, Name = "Dragon18", Health = (short)85 , Created = DateTime.Now });
        }
    }
}
