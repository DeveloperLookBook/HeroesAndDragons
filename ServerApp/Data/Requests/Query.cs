using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;
using ServerApp.Models.Characters.Heroes;

namespace ServerApp.Data.Requests
{
    public class Query<TModel> : IQuery<TModel> where TModel : class, IModel
    {
        #region FIELDS

        private IQuery<TModel> next;

        #endregion


        #region PROPERTIES

        public IQuery<TModel> Next
        {
            get => this.next;
            set => this.next = value ?? throw new ArgumentNullException(nameof(value));
        }

        IQuery<IModel> IQuery.Next
        {
            get => (IQuery<IModel>)this.next;
            set => this.Next = (IQuery<TModel>)value;
        }

        #endregion


        #region DELEGATES

        public BuildQueryFunc<TModel> Build { get; }

        BuildQueryFunc IQuery.Build
        {
            get => (BuildQueryFunc)Delegate.CreateDelegate(typeof(BuildQueryFunc), this.Build.Target, this.Build.Method);
        }

        #endregion


        #region CONSTRUCTORS

        public Query(BuildQueryFunc<TModel> func) => this.Build = func ?? throw new ArgumentNullException(nameof(func));

        #endregion


        #region METHODS

        public static Query<TModel> CreateQuery(BuildQueryFunc<TModel> func) => new Query<TModel>(func);

        #endregion
    }
}
