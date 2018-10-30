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
                .Must(n => n.SentenceCased()).WithMessage(DragonContract.Messages.Get(DragonContract.Key.NameIsNotSentenceCased))
                .Must(n => n.HasNumbers   ()).WithMessage(DragonContract.Messages.Get(DragonContract.Key.NameContainsNumbers   ));

            RuleFor<int>(d => d.Health)
                .LessThan   (0  ).WithMessage(DragonContract.Messages.Get(DragonContract.Key.HealthIsLess0     ))
                .GreaterThan(100).WithMessage(DragonContract.Messages.Get(DragonContract.Key.HealthIsGreater100));
        }
    }
}
