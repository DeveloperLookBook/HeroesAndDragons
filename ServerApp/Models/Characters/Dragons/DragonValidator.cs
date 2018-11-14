using FluentValidation;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    public class DragonValidator : CharacterValidator<Dragon>
    {
        public DragonValidator()
        {
            RuleFor(d => d.Name)
                .Must(n => n.SentenceCased()).WithMessage("First letter in the Dragon name must be uppercased.")
                .Must(n => n.HasNoNumbers ()).WithMessage("Dragon Name mustn't contain numbers.");

            RuleFor<int>(d => d.Health)
                .GreaterThanOrEqualTo(0 ).WithMessage("Dragon Health mustn't be less then 0.")
                .LessThanOrEqualTo   (10).WithMessage("Dragon Health mustn't be greater then 100.");
        }
    }
}
