using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Swords
{
    public class SwordSeeds : IEntityTypeConfiguration<Sword>
    {
        public void Configure(EntityTypeBuilder<Sword> builder)
        {
            builder.HasData(new { Id = WeaponType.Sword, Name = "Sword", Strength = 35 });
        }
    }
}
