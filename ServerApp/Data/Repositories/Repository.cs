using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServerApp.Data.Requests;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class, Models.IModel
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

        public IQueryable<TModel> Request() => this.Models;

        public void Add   (TModel model)
        {
            Models.Add(model);
            Context.SaveChanges());

            return this;
        }
        public void Add   (IEnumerable<TModel> models)
        {
            this.Models.AddRange(models);
            this.Context.SaveChanges();
        }
        public void Remove(TModel model)
        {
            this.Models.Remove(model);
            this.Context.SaveChanges();
        }
        public void Remove(IEnumerable<TModel> models)
        {
            this.Models.RemoveRange(models);
            this.Context.SaveChanges();
        }
        public void Update(TModel model)
        {
            this.Models.Update(model);
            this.Context.SaveChanges();
        }
        public void Update(IEnumerable<TModel> models)
        {
            this.Models.UpdateRange(models);
            this.Context.SaveChanges();
        }

        #endregion
    }
}
