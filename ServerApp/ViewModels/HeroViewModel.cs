using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public class HeroViewModel : ViewModel<int>
    {
        public string          Name    { get; set; }
        public WeaponViewModel Weapon  { get; set; }
        public DateTime        Created { get; set; }

        public HeroViewModel()
        {

        }

        #region PROTOTYPE PATTERN

        public HeroViewModel(HeroViewModel viewModel)
        {
            this.Name    = viewModel.Name;
            this.Weapon  = viewModel.Weapon;
            this.Created = viewModel.Created;
        }

        public override IViewModel<int> Clone()
        {
            return new HeroViewModel(this);
        }

        #endregion
    }
}
