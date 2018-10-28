using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Requests
{
    public class RequestBuilder<TModel> where TModel : class, Models.IModel
    {
        #region PROPERTIES

        private IQueryable<TModel> Query { get; }

        #endregion


        #region CONSTRUCTORS

        public RequestBuilder(IQueryable<TModel> query) => this.Query = query ?? throw new ArgumentNullException(nameof(query));

        #endregion


        #region METHODS

        public        IQueryable<TModel>     GetQuery      (                            ) => this.Query;
        public        IEnumerable<TModel>    GetEnumerable (                            ) => this.Query.AsEnumerable();
        public static RequestBuilder<TModel> CreateBuilder (IQueryable<TModel> queryable) => new RequestBuilder<TModel>(queryable);

        #endregion
    }
}
