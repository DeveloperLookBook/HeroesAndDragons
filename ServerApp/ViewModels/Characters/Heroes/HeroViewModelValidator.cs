using FluentValidation;
using ServerApp.Extencions;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels.Characters.Heroes
{
    public class HeroViewModelValidator : AbstractValidator<CreateHeroViewModel>, IValidator<CreateHeroViewModel>
    {
        private bool HasNoDisallowedSeparators(string value) => value.IsMatch(@"\A[\P{Z} ]*\z"     );
        private bool HasNoDisallowedLetters   (string value) => value.IsMatch(@"\A[\P{L}a-zA-Z]*\z");

        public HeroViewModelValidator()
        {
            RuleFor(h => h.Name)
                .NotNull      (  ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameIsNull               ))
                .NotEmpty     (  ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameIsEmpty              ))
                .MaximumLength(20).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameLengthIsGreaterThen20))
                .MinimumLength(4 ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameLengthIsLessThen4    ))

                .Must(n => n.Trimed()          ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameIsNotTrimed            ))
                .Must(HasNoDisallowedSeparators).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameHasDisallowedSeparators))
                .Must(HasNoDisallowedLetters   ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameHasDisallowedLetters   ))

                .Must(n => n.HasNoPunctuation()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasPuncuation))
                .Must(n => n.HasNoMarks      ()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasMarks     ))
                .Must(n => n.HasNoSymbols    ()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasSymbols   ))
                .Must(n => n.HasNoControls   ()).WithMessage(HeroContract.Messages.Get(HeroContract.Key.NameHasControls  ));
        }
    }
}
