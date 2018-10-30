using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Weapons.Crossbows
{
    public class CrossbowSeeds : WeaponConfiguration
    {
        public override void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasData(new { Id = WeaponType.Crossbow, Name = "Crossbow", Strength = 60 });
        }
    }
}
