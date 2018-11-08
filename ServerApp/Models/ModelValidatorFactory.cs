using FluentValidation;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public interface IModelValidatorCreator
    {
        DragonValidator DragonValidator();
        HeroValidator   HeroValidator  ();
        HitValidator    HitValidator   ();
        WeaponValidator WeaponValidator();
    }


    public delegate TModelValidator ModelValidatorFactorySelectorFunc<TModelValidator>(IModelValidatorCreator creator) 
        where TModelValidator : IValidator;


    public static class ModelValidatorFactory
    {
        private class Creator : IModelValidatorCreator
        {
            public DragonValidator DragonValidator() => new DragonValidator();
            public HeroValidator   HeroValidator  () => new HeroValidator  ();
            public HitValidator    HitValidator   () => new HitValidator   ();
            public WeaponValidator WeaponValidator() => new WeaponValidator();
        }


        static private Creator InstanceCreator => new Creator();


        static public TModelValidator Create<TModelValidator>(ModelValidatorFactorySelectorFunc<TModelValidator> selector) 
            where TModelValidator : IValidator
        {
            return selector(InstanceCreator);
        }

        static public IValidator<TModel> Create<TModel>() where TModel : class, IModel
        {
            var type = typeof(TModel);

            if (type.Equals(typeof(DragonValidator))) return Create(s => s.DragonValidator()) as IValidator<TModel>;
            if (type.Equals(typeof(HeroValidator  ))) return Create(s => s.HeroValidator  ()) as IValidator<TModel>;
            if (type.Equals(typeof(HitValidator   ))) return Create(s => s.HitValidator   ()) as IValidator<TModel>;
            if (type.Equals(typeof(WeaponValidator))) return Create(s => s.WeaponValidator()) as IValidator<TModel>;

            throw new ArgumentException("Selected generic type doesn't exist.");
        }
    }    
}
