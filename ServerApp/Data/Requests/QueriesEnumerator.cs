using ServerApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Requests
{
    public class QueriesEnumerator<TModel> : IEnumerator<IQuery<TModel>> where TModel : class, IModel
    {

        #region PROPERTIES

        private IQuery<TModel> First   { get;         set; }
        public  IQuery<TModel> Current { get; private set; }

        object     IEnumerator.Current => this.Current;

        #endregion

        #region CONSTRUCTORS

        public QueriesEnumerator(IQuery<TModel> query) => this.First = query;

        #endregion


        #region METHODS

        public void Dispose () => this.Current = this.First = null;
        public bool MoveNext() => !((this.Current = (this.Current is null) ? this.First : this.Current.Next) is null);
        public void Reset   () => this.Current = this.First;

        #endregion
    }
}
