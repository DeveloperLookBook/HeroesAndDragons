using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public class WeaponViewModel : ViewModel<int>
    {
        public string Name     { get; set; }
        public short  Strength { get; set; }

        public WeaponViewModel()
        {

        }

        #region PROTOTYPE PATTERN

        protected WeaponViewModel(WeaponViewModel viewModel)
        {
            this.Name     = viewModel.Name;
            this.Strength = viewModel.Strength;
        }

        public override IViewModel<int> Clone()
        {
            return new WeaponViewModel(this);
        }

        #endregion
    }
}
