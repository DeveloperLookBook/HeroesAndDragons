using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Requests
{
    public delegate IQueryable<Models.IModel> BuildQueryFunc(IQueryable<Models.IModel> models);

    public delegate IQueryable<TModel> BuildQueryFunc<TModel>(IQueryable<TModel> models) where TModel: class, Models.IModel;
}
