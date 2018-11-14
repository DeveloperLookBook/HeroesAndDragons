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
    public class CreateHeroViewModelValidator : AbstractValidator<SignupHeroViewModel>, IValidator<SignupHeroViewModel>
    {
        private bool HasNoDisallowedSeparators(string value) => value.IsMatch(@"\A[\P{Z} ]*\z"     );
        private bool HasNoDisallowedLetters   (string value) => value.IsMatch(@"\A[\P{L}a-zA-Z]*\z");

        public CreateHeroViewModelValidator()
        {
            RuleFor(h => h.Name)
                .NotNull      (  ).WithMessage("Name mustn't be Null.")
                .NotEmpty     (  ).WithMessage("Name mustn't be Empty.")
                .MaximumLength(20).WithMessage("Name Length must be less or equal - 20.")
                .MinimumLength(4 ).WithMessage("Name Length must be more or equal - 4.")


                .Must(n => n.Trimed()          ).WithMessage("Name must be Trimmed.")
                .Must(n => n.SentenceCased()   ).WithMessage("First Name letter must be uppercased.")
                .Must(HasNoDisallowedSeparators).WithMessage("Name mustn't contain any separator characters except white-spaces")
                .Must(HasNoDisallowedLetters   ).WithMessage("Name can contain Latin letters only: a-z, A-Z.")

                .Must(n => n.HasNoPunctuation()).WithMessage("Name mustn't contain Punctuation characters.")
                .Must(n => n.HasNoMarks      ()).WithMessage("Name mustn't contain Nonspacing, Spacing Combining and Enclosing diacritic marks.")
                .Must(n => n.HasNoSymbols    ()).WithMessage("Name mustn't contain: Math, Currency and Modifier symbols.")
                .Must(n => n.HasNoControls   ()).WithMessage("Name mustn't contain: Control, Format, Surrogate, Private Use and Not Assigned control characters.");
        }
    }
}
