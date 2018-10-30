using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Weapons.Rapiers
{
    public class RapierSeeds : WeaponConfiguration
    {
        public override void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasData(new { Id = WeaponType.Rapier, Name = "Rapier", Strength = 40 });
        }
    }
}
