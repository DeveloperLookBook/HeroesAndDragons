using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Characters.Dragons
{
    [NotMapped]
    public class DragonConfiguration : CharacterConfiguration<Dragon>
    {
        public override void Configure(EntityTypeBuilder<Dragon> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.Name  ).HasField("_name"       ).IsRequired().HasMaxLength(20);
            builder.Property(d => d.Health).HasField("_health");
        }
    }
}
