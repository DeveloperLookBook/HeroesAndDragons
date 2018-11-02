using ServerApp.Data.Requests;
using ServerApp.Models;
using ServerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations
{
    public class View<TViewModel> : IView<TViewModel> where TViewModel : class, IViewModel
    {
        #region PROPERTIES

        public IViewParams      Params { get; private set; }       
        public List<TViewModel> Models { get; private set; }
        List<IViewModel>  IView.Models => new List<IViewModel>(this.Models);

        #endregion


        #region CONSTRUCTORS               

        public View(List<TViewModel> models, IViewParams parameters)
        {
            this.Models = models;
            this.Params = parameters;
        }

        #endregion


        #region CONVERSIONS

        public static explicit operator View<TViewModel>(View<IViewModel> view)
        {
            IViewParams      @params = view.Params;
            List<TViewModel> models  = new List<TViewModel>(view.Models.Count);

            view.Models.ForEach((i) => models.Add((TViewModel)i));

            return new View<TViewModel>(models, @params);
        }

        public static explicit operator View<IViewModel>(View<TViewModel> view)
        {
            IViewParams      @params = view.Params;
            List<IViewModel> models  = new List<IViewModel>(view.Models.Count);

            view.Models.ForEach((i) => models.Add(i));

            return new View<IViewModel>(models, @params);
        }

        public static explicit operator View<TViewModel>(View<HeroViewModel> view)
        {
            IViewParams      @params = view.Params;
            List<TViewModel> models  = new List<TViewModel>(view.Models.Count);

            view.Models.ForEach((i) => models.Add(i as TViewModel));

            return new View<TViewModel>(models, @params);        }

        public static explicit operator View<TViewModel>(View<DragonViewModel> view)
        {
            IViewParams      @params = view.Params;
            List<TViewModel> models  = new List<TViewModel>(view.Models.Count);

            view.Models.ForEach((i) => models.Add(i as TViewModel));

            return new View<TViewModel>(models, @params);
        }

        #endregion
    }
}
