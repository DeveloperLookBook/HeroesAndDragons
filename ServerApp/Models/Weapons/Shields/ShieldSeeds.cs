using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Weapons.Shields
{
    public class ShieldSeeds : WeaponConfiguration
    {
        public override void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasData(new { Id = WeaponType.Shield, Name = "Shield", Strength = 20 });
        }
    }
}
