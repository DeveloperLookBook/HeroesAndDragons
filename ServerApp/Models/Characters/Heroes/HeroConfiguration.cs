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
            builder.HasIndex(h => h.Name).IsUnique();
        }
    }
}
