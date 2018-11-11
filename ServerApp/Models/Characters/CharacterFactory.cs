using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters
{
    public interface ICharacterCreator
    {
        Hero   Hero  (string name);
        Dragon Dragon();
    }


    public delegate TCharacter CharacterFactorySelectorFunc<TCharacter>(ICharacterCreator creator) where TCharacter : class, ICharacter;


    [NotMapped]
    public static class CharacterFactory
    {
        private class CharacterCreator : ICharacterCreator
        {
            static public DragonHealth        DragonHealthGenerator => new DragonHealth        ();
            static public DragonNameGenerator DragonNameGenerator   => new DragonNameGenerator ();


            public Hero   Hero  (string name) => new Hero  (name, WeaponFactory.Create(s => s.Random()));
            public Dragon Dragon(           ) => new Dragon(DragonNameGenerator.Generate(), DragonHealthGenerator.Generate());


            public Hero   Hero(SigninHeroViewModel viewModel) => this.Hero(viewModel.Name);
        }


        static private CharacterCreator InstanceCreator => new CharacterCreator();


        static public TCharacter Create<TCharacter>(CharacterFactorySelectorFunc<TCharacter> selector) where TCharacter : class, ICharacter
        {
            if (selector is null) { throw new ArgumentNullException(nameof(selector)); }

            return selector(InstanceCreator);
        }        
    }    
}
