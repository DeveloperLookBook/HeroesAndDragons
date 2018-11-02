using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public class DragonViewModel : ViewModel<int>
    {
        public string   Name    { get; set; }
        public short    Health  { get; set; }
        public DateTime Created { get; set; }

        public DragonViewModel()
        {

        }

        #region PROTOTYPE PATTERN

        protected DragonViewModel(DragonViewModel viewModel) : base(viewModel)
        {

            this.Name    = viewModel.Name;
            this.Health  = viewModel.Health;
            this.Created = viewModel.Created;
        }

        public override IViewModel<int> Clone()
        {
            return new DragonViewModel(this);
        }

        #endregion
    }   
}
