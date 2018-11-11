using FluentValidation;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters
{
    [NotMapped]
    public abstract class CharacterValidator<TModel> : AbstractValidator<TModel> where TModel : Character
    {
        private bool HasNoDisallowedSeparators(string value) => value.IsMatch(@"\A[\P{Z} ]*\z"     );
        private bool HasNoDisallowedLetters   (string value) => value.IsMatch(@"\A[\P{L}a-zA-Z]*\z");

        public CharacterValidator()
        {
            RuleFor(c => c.Name)
                .NotNull      (               ).WithMessage("Name mustn't be Null.")
                .NotEmpty     (               ).WithMessage("Name mustn't be Empty.")
                .Must         (n => n.Trimed()).WithMessage("Name must be Trimmed.")
                .MaximumLength(20             ).WithMessage("Name Length must be less or equal - 20.")
                .MinimumLength(4              ).WithMessage("Name Length must be more or equal - 4.")

                .Must(HasNoDisallowedSeparators).WithMessage("Name mustn't contain any separator characters except white-spaces")
                .Must(HasNoDisallowedLetters   ).WithMessage("Name can contain Latin letters only: a-z, A-Z.");
        }
    }
}
