using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Extencions;

namespace ServerApp.Models.Characters.Heroes
{
    public class HeroValidator : CharacterValidator<Hero>
    {
        public HeroValidator()
        {
            RuleFor(h => h.Name)
                .Must(n => n.HasNoPunctuation()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasPuncuation))
                .Must(n => n.HasNoMarks      ()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasMarks     ))
                .Must(n => n.HasNoSymbols    ()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasSymbols   ))
                .Must(n => n.HasNoControls   ()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasControls  ));

            RuleFor(h => h.Weapon)
                .NotNull().WithMessage(HeroContract.Messages.Get(HeroContract.Key.WeaponIsNull));
        }
    }
}
