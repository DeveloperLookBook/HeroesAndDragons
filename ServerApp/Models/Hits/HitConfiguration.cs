using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Hits
{
    [NotMapped]
    public class HitConfiguration : ModelConfiguration<Hit, Guid>
    {
        public override void Configure(EntityTypeBuilder<Hit> builder)
        {
            base.Configure(builder);

            builder.Property(h => h.Hero    ).HasField("_hero"    ).IsRequired();
            builder.Property(h => h.Dragon  ).HasField("_dragon"  ).IsRequired();
            builder.Property(h => h.Weapon  ).HasField("_weapon"  ).IsRequired();
            builder.Property(h => h.Strength).HasField("_strength");            
        }
    }
}
