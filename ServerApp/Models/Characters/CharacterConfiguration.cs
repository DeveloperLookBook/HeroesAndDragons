using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerApp.Models.Characters
{
    [NotMapped]
    public class CharacterConfiguration<TModel> : ModelConfiguration<TModel, Guid> where TModel : Character
    {
        public override void Configure(EntityTypeBuilder<TModel> builder)
        {
            base.Configure(builder);
        }
    }
}
