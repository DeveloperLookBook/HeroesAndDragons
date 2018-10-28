using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public class WeaponValidator : AbstractValidator<Weapon>
    {
        public WeaponValidator()
        {
            RuleFor<int>(w => w.Strength)
                .LessThan   (1  ).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.StrengthLessThen1  ))
                .GreaterThan(100).WithMessage(WeaponContract.Messages.Get(WeaponContract.Key.StrengthMoreThen100));
        }
    }
}
