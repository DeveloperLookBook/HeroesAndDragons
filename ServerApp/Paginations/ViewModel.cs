using ServerApp.Data.Requests;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations
{
    public class ViewModel<TModel> : List<TModel> where TModel : IModel
    {
        #region PROPERTIES

        public  int  PageNumber  { get; private set; }
        public  int  PageSize    { get; private set; }
        public  int  ModelsCount { get; private set; }

        public  int  PageCount   => (int)Math.Ceiling(this.ModelsCount / (double)this.PageSize);
        private bool HasPrevious => (this.PageNumber > 1);
        private bool HasNext     => (this.PageNumber < this.PageCount);

        #endregion


        #region CONSTRUCTOR

        protected ViewModel(List<TModel> models, int pageNumber, int pageSize, int modelsCount)
        {
            this.AddRange(models);

            this.PageNumber  = pageNumber;
            this.PageSize    = pageSize;
            this.ModelsCount = modelsCount;
        }

        #endregion


        #region FACTORY METHOD

        static ViewModel<TModel> Create(IQueryable<TModel> source, int pageNumber, int pageSize)
        {
            var modelsCount = (int)source.Count();
            var models      = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new ViewModel<TModel>(models, pageNumber, pageSize, modelsCount);
        }

        #endregion
    }
}
