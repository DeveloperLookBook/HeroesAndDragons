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
                .Must(n => n.HasNoPunctuation()).WithMessage("Name mustn't contain Punctuation characters.")
                .Must(n => n.HasNoMarks      ()).WithMessage("Name mustn't contain Nonspacing, Spacing Combining and Enclosing diacritic marks.")
                .Must(n => n.HasNoSymbols    ()).WithMessage("Name mustn't contain: Math, Currency and Modifier symbols.")
                .Must(n => n.HasNoControls   ()).WithMessage("Name mustn't contain: Control, Format, Surrogate, Private Use and Not Assigned control characters.");

            RuleFor(h => h.Weapon)
                .NotNull().WithMessage("Hero Weapon mustn't be Null.");
        }
    }
}
