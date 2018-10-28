using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Characters.Heroes
{
    [NotMapped]
    public class HeroConfiguration : CharacterConfiguration<Hero>
    {
        public override void Configure(EntityTypeBuilder<Hero> builder)
        {
            base.Configure(builder);
            
            builder.Property(h => h.Name  ).HasField("_name"  ).IsRequired().HasMaxLength(20);
            builder.HasIndex(h => h.Name  ).IsUnique();

            builder.Property(h => h.Weapon).HasField("_weapon").IsRequired();
        }
    }
}
