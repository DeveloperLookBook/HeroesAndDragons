using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
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

        private   GameDbContext Context => this.context;
        protected DbSet<TModel> Models  { get; }

        #endregion


        #region CONSTRUCTORS

        public Repository(GameDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.Models  = this.Context.Set<TModel>();            
        }

        #endregion


        #region HELPER METHODS

        /// <summary>
        /// Method that used to be applied to attach singletons to the DB context.
        /// </summary>
        /// <remarks>
        /// In this project, weapon should be attached to the context before saving 
        /// or updating it directly, or saving it with models that are referencing
        /// on some kinds of weapon that were saved in DB already.
        /// </remarks>
        /// <typeparam name="TAttachableModel">Model type that should be attached 
        /// to the DB context.</typeparam>
        /// <param name="model">Model instance that should be attached to the DB 
        /// context.</param>
        /// <returns>Returns true if model was attached to the DB context.</returns>
        protected bool TryToAttach<TAttachableModel>(TAttachableModel model) where TAttachableModel : class, Models.IModel
        {
            var models     = this.Context.Set<TAttachableModel>();
            var isAttached = false;

            if (models.Contains(model))
            {
                models.Attach(model);
                isAttached = true;
            }

            return isAttached;
        }

        private void ChangeState       (TModel              model , EntityState state)
        {
            this.Context.Entry(model).State = state;
        }
        private void ChangeState       (IEnumerable<TModel> models, EntityState state)
        {
            foreach (var model in models) { this.ChangeState(model, state); }
        }
        private void ChangeStateAndSave(TModel              model , EntityState state)
        {
            this.ChangeState(model, state);
            this.Context.SaveChanges();
        }
        private void ChangeStateAndSave(IEnumerable<TModel> models, EntityState state)
        {
            this.ChangeState(models, state);
            this.Context.SaveChanges();
        }

        #endregion


        #region API METHODS              

        public IQueryable<TModel> Request() => this.Models;

        virtual public void Add   (TModel              model ) => this.ChangeStateAndSave(model , EntityState.Added   );
        virtual public void Add   (IEnumerable<TModel> models) => this.ChangeStateAndSave(models, EntityState.Added   );
                public void Remove(TModel              model ) => this.ChangeStateAndSave(model , EntityState.Deleted );
                public void Remove(IEnumerable<TModel> models) => this.ChangeStateAndSave(models, EntityState.Deleted );
        virtual public void Update(TModel              model ) => this.ChangeStateAndSave(model , EntityState.Modified);
        virtual public void Update(IEnumerable<TModel> models) => this.ChangeStateAndSave(models, EntityState.Modified);


        IQueryable<object> IRepository.Request() => this.Request();

        public void Add   (IEnumerable<object> models) => this.Add   ((IEnumerable<TModel>)models);
        public void Add   (object              model ) => this.Add   ((TModel)model              );
        public void Remove(IEnumerable<object> models) => this.Remove((IEnumerable<TModel>)models);
        public void Remove(object              model ) => this.Remove((TModel)model              );
        public void Update(IEnumerable<object> models) => this.Update((IEnumerable<TModel>)models);
        public void Update(object              model ) => this.Update((TModel)model              );

        #endregion
    }
}
