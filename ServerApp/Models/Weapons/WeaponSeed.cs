using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApp.Models.Weapons.Axes;
using ServerApp.Models.Weapons.Crossbows;
using ServerApp.Models.Weapons.Knifes;
using ServerApp.Models.Weapons.Rapiers;
using ServerApp.Models.Weapons.Shields;
using ServerApp.Models.Weapons.Swords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public class WeaponSeed : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasData(
                WeaponFactory.Create<Axe>     (),
                WeaponFactory.Create<Crossbow>(),
                WeaponFactory.Create<Knife>   (),
                WeaponFactory.Create<Rapier>  (),
                WeaponFactory.Create<Shield>  (),
                WeaponFactory.Create<Sword>   ()
                );
        }
    }
}
