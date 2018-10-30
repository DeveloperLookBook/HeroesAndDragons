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
            RuleFor     (h => h.Hero    ).NotNull    (   ).WithMessage(HitContract.Messages.Get(HitContract.Key.HeroIsNull       ));
            RuleFor     (h => h.Dragon  ).NotNull    (   ).WithMessage(HitContract.Messages.Get(HitContract.Key.DragonIsNull       ));
            RuleFor     (h => h.Weapon  ).NotNull    (   ).WithMessage(HitContract.Messages.Get(HitContract.Key.WeaponIsNull       ));
            RuleFor<int>(h => h.Strength).LessThan   (1  ).WithMessage(HitContract.Messages.Get(HitContract.Key.StrengthLessThen1  ));
            RuleFor<int>(h => h.Strength).GreaterThan(100).WithMessage(HitContract.Messages.Get(HitContract.Key.StrengthMoreThen100));
        }
    }
}
