using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Requests
{
    public interface IQueries<TModel> : IEnumerable<IQuery<TModel>> where TModel : class, IModel
    {
        void Append(BuildQueryFunc<TModel> func );
        void Append(IQuery<TModel>         query);
    }
}
