using ServerApp.ViewModels;
using System.Collections.Generic;

namespace ServerApp.Paginations
{
    public interface IView
    {
        IViewParams      Params { get; }
        List<IViewModel> Models { get; }
    }

    public interface IView<TViewModel> : IView where TViewModel : class, IViewModel
    {
        new List<TViewModel> Models { get; }
    }
}