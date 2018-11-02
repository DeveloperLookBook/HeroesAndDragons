using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public abstract class ViewModel<TId> : IViewModel<TId> where TId : IComparable<TId>
    {
        private TId _id;

        public TId        Id { get => this._id; set => this._id = value;     }
        object IViewModel.Id { get => this.Id;  set => this.Id = (TId)value; }

        public ViewModel()
        {

        }

        #region PROTOTYPE PATTERN

        protected ViewModel(ViewModel<TId> viewModel)
        {
            if (viewModel is null) throw new ArgumentNullException(nameof(viewModel));

            this.Id = viewModel.Id;
        }

        public abstract IViewModel<TId> Clone();
        IViewModel IViewModel.Clone() => this.Clone();

        #endregion
    }
}
