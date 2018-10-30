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
                .NotNull      (  ).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.NameIsNull               ))
                .NotEmpty     (  ).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.NameIsEmtpy              ))
                .MaximumLength(20).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.NameLengthIsGreaterThen20))
                .Must(n => n.Trimed()).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.NameIsNotTrimed));

            RuleFor<int>(w => w.Strength)
                .LessThan   (1  ).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.StrengthLessThen1  ))
                .GreaterThan(100).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.StrengthMoreThen100));
        }
    }
}
