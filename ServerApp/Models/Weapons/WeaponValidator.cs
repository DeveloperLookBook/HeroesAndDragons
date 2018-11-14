using FluentValidation;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    [NotMapped]
    public class WeaponValidator : AbstractValidator<Weapon>
    {
        public WeaponValidator()
        {
            RuleFor(w => w.Name)
                .NotNull          (  ).WithMessage("Weapon Name mustn't be Null.")
                .NotEmpty         (  ).WithMessage("Weapon Name mustn't be Empty.")
                .MaximumLength    (20).WithMessage("Weapon Name Length must be less or equal - 20.")
                .Must(n => n.Trimed()).WithMessage("Weapon Name must be Trimmed.");

            RuleFor<int>(w => w.Strength)
                .GreaterThanOrEqualTo(1  ).WithMessage("Weapon Strength value must be more or equal to 1.")
                .LessThanOrEqualTo   (100).WithMessage("Weapon Strength value must be less or equal to 100.");
        }
    }
}
