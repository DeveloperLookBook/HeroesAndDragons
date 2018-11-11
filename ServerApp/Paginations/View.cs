using ServerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations
{
    public class View<TViewModel> : IView<TViewModel> where TViewModel : class
    {
        #region PROPERTIES

        public IViewParams      Params { get; private set; }       
        public List<TViewModel> Models { get; private set; }

        List<object>      IView.Models => new List<object>(this.Models);

        #endregion


        #region CONSTRUCTORS               

        public View(List<TViewModel> models, IViewParams parameters)
        {
            this.Models = models;
            this.Params = parameters;
        }

        #endregion        
    }
}
