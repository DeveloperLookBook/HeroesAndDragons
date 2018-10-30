using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Weapons.Knifes
{
    public class KnifeSeeds : WeaponConfiguration
    {
        public override void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasData(new { Id = WeaponType.Knife, Name = "Knife", Strength = 30 });
        }
    }
}
