using Microsoft.EntityFrameworkCore;
using ServerApp.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class Repository<TModel> where TModel : class, Models.IModel
    {
        #region FIELDS

        private readonly GameDbContext context;

        #endregion


        #region PROPERTIES

        private GameDbContext Context => this.context;
        private DbSet<TModel> Models  { get; }

        #endregion


        #region CONSTRUCTORS

        public Repository(GameDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.Models  = this.Context.Set<TModel>();
            
        }

        #endregion


        #region METHODS

        /// <summary>
        /// Request builder factory method.
        /// </summary>
        /// <returns>Request builder instance.</returns>
        protected RequestBuilder<TModel> CreateRequestBuilder() 
        {
            return new RequestBuilder<TModel>(this.Models);
        }        

        public RequestBuilder<TModel> Request()
        {
            return this.CreateRequestBuilder();
        }

        public void Create()
        {

        }
        public void Delete()
        {

        }
        public void Update()
        {

        }

        #endregion
    }
}
