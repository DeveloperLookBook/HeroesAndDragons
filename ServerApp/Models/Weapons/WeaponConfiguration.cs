using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Weapons
{
    [NotMapped]
    public class WeaponConfiguration : ModelConfiguration<Weapon, int>
    {
        public override void Configure(EntityTypeBuilder<Weapon> builder)
        {
            base.Configure(builder);

            builder.Property(w => w.Name    ).IsRequired().HasMaxLength(20);
            builder.Property(w => w.Strength);
        }
    }
}
