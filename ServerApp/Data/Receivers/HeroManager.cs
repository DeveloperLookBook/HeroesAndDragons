using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerApp.Data.Requests;
using ServerApp.Data.UnitOfWorks;
using ServerApp.Extencions;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using ServerApp.ViewModels.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Receivers
{
    public class HeroManager : CharacterManager
    {
        public Task<IActionResult> SigupActionResult { get; protected set; }

        public void Run(
            string       commandCode,
            IGameContext gameContext,
            IHero        hero        = null,
            IDragon      dragon      = null,
            object       viewModel   = null)
        {
            if (commandCode is null) { throw new ArgumentNullException(nameof(commandCode)); }
            if (gameContext is null) { throw new ArgumentNullException(nameof(gameContext)); }            

            var command = commandCode.ToUpper().Trim();
            
            switch (commandCode)
            {
                case "HIT_DRAGON" : this.HitDragon(gameContext, hero, dragon)                   ; break;
                case "SIGNUP_HERO": this.SigupActionResult = this.SignupAsync(gameContext, viewModel); break;

                default:                                                            break;
            }
        }

        private void  HitDragon        (IGameContext gameContext, IHero hero, IDragon dragon)
        {            
            gameContext.Hits.Add(HitFactory.Create(hero, dragon, hero.Weapon));
        }           



        #region SIGNUP_HERO

        private Task<IActionResult> SignupAsync(IGameContext gameContext, object heroSignupViewModel)
        {
            if (gameContext         is null) { throw new ArgumentNullException(nameof(gameContext        )); }
            if (heroSignupViewModel is null) { throw new ArgumentNullException(nameof(heroSignupViewModel)); }

            if (!(heroSignupViewModel is SignupHeroViewModel))
            {
                throw new ArgumentException(
                    "View model must have - \"HeroSignupViewModel\" type.", 
                    nameof(heroSignupViewModel));
            }

            var view = heroSignupViewModel as SignupHeroViewModel;   
            

        }
                   
        
        private BadRequestObjectResult       CreateBadRequestObjectResult      (ModelStateDictionary state, int? statusCode = 400)
        {
            return new BadRequestObjectResult(state)
            {
                StatusCode = statusCode,                
            };
        }
        private bool                         IsViewModelValid                  (SignupHeroViewModel viewModel, out ModelStateDictionary state)
        {
            state = ModelStateDictionaryFactory.Create();

            var validator = this.CreateHeroSignupViewModelValidator();
            var result    = validator.Validate(viewModel);
            var isValid   = result.IsValid;

            if (!isValid) { state = result.ToModelStateDictionary(); }

            return isValid;
        }

        private async Task<bool>             ValidateHeroSignupViewModelAsync(IGameContext gameContext, SignupHeroViewModel viewModel, out ModelStateDictionary state)
        {
            if (gameContext is null) { throw new ArgumentNullException(nameof(gameContext)); }
            if (viewModel   is null) { throw new ArgumentNullException(nameof(viewModel  )); }

            if (this.IsViewModelValid(viewModel, out state)) return false;

            var heroes = gameContext.Heroes.Request();

            // Check, if user name already used by another user.
            {
                var isNameEngaged = await heroes.HaveNamesEqualToAsync(viewModel.Name);

                if (isNameEngaged)
                {
                    var propertyName = nameof(HeroSigninViewModel.Name);
                    var errorMessage = $@"Hero name - {propertyName} is already used by another user.";

                    state = ModelStateDictionaryFactory.Create(new KeyValuePair<string, string>(propertyName, errorMessage));
                }
            }
        }
        private async Task<IActionResult>    CreateSigupActionResultAsync(IGameContext gameContext, SignupHeroViewModel viewModel)
        {
            
            
                  
        }

        #endregion


    }
}
