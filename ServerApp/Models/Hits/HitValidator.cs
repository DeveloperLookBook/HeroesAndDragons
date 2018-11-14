using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    [NotMapped]
    public class HitValidator : AbstractValidator<Hit>
    {
        public HitValidator()
        {
            RuleFor(h => h.Source).NotNull().WithMessage("Hit Source mustn't be Null.");
            RuleFor(h => h.Target).NotNull().WithMessage("Hit Target mustn't be Null.");
            RuleFor(h => h.Weapon).NotNull().WithMessage("Hit Weapon mustn't be Null.");

            RuleFor<int>(h => h.Strength).GreaterThanOrEqualTo(1  ).WithMessage("Hit Strength value must be more or equal to 1.");
            RuleFor<int>(h => h.Strength).LessThanOrEqualTo   (100).WithMessage("Hit Strength value must be less or equal to 100.");
        }
    }
}
