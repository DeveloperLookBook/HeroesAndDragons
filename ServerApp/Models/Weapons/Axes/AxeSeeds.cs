using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Weapons.Axes
{
    public class AxeSeeds : WeaponConfiguration
    {
        public override void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasData(new { Id = WeaponType.Axe, Name = "Axe", Strength = 50 });
        }
    }
}
