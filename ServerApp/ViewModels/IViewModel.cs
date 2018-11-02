using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public interface IViewModel
    {
        object  Id { get; set; }

        IViewModel Clone();
    }

    public interface IViewModel<TId> : IViewModel where TId : IComparable<TId>
    {
        new TId Id { get; set; }

        new IViewModel<TId> Clone();
    }
}
