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
        private bool HasDisallowedSeparators(string value) => value.IsMatch(@"\A[\P{Z} ]*\z"     );
        private bool HasDisallowedLetters   (string value) => value.IsMatch(@"\A[\P{L}a-zA-Z]*\z");

        public CharacterValidator()
        {
            RuleFor(c => c.Name)
                .NotNull      (               ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameIsNull               ))
                .NotEmpty     (               ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameIsEmpty              ))
                .Must         (n => n.Trimed()).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameIsNotTrimed          ))
                .MaximumLength(20             ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameLengthIsGreaterThen20))
                .MinimumLength(4              ).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameLengthIsLessThen4    ))

                .Must(n => HasDisallowedSeparators(n)).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameHasDisallowedSeparators))
                .Must(n => HasDisallowedLetters   (n)).WithMessage(CharacterContract.Messages.Get(CharacterContract.Key.NameHasDisallowedLetters   ));
        }
    }
}
