using ServerApp.ViewModels;
using System.Collections.Generic;

namespace ServerApp.Paginations
{
    public interface IView
    {
        IViewParams  Params { get; }
        List<object> Models { get; }
    }

    public interface IView<TViewModel> : IView where TViewModel : class
    {
        new List<TViewModel> Models { get; }
    }
}