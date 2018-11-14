using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApp.Models.Characters;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Hits
{
    [NotMapped]
    public class HitConfiguration : ModelConfiguration<Hit, Guid>
    {
        public override void Configure(EntityTypeBuilder<Hit> builder)
        {
            base.Configure(builder);

            builder.Property(h => h.Strength);
        }
    }
}
