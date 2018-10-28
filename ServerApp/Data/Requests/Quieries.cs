using ServerApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Requests
{
    public class Queries<TModel> : IQueries<TModel> where TModel: class, IModel
    {
        #region FIELDS

        private IQuery<TModel> first;
        private IQuery<TModel> last ;       
            
        #endregion


        #region PROPERTIES

        private IQuery<TModel> First
        {
            get => this.first;
            set => this.first = value ?? throw new ArgumentNullException(nameof(value));
        }

        private IQuery<TModel> Last
        {
            get => this.last;
            set => this.last = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion


        #region METHODS

        public static Queries<TModel> CreateQueries() => new Queries<TModel>();

        public void Append(IQuery<TModel>         query) => this.Last = (this.First is null) ? this.First = query : this.Last.Next = query;    
        public void Append(BuildQueryFunc<TModel> func ) => this.Append(Query<TModel>.CreateQuery(func));

        public IEnumerator<IQuery<TModel>> GetEnumerator() => new QueriesEnumerator<TModel>(this.First);
               IEnumerator     IEnumerable.GetEnumerator() => this.GetEnumerator();

        #endregion
    }
}
