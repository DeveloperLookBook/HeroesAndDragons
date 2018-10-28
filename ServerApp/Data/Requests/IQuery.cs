using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Requests
{
    public interface IQuery
    {
        IQuery <Models.IModel> Next  { get; set; }
        BuildQueryFunc         Build { get;      }
    }

    public interface IQuery<TModel>: IQuery where TModel :class, Models.IModel
    {
        new IQuery <TModel>        Next  { get; set; }
        new BuildQueryFunc<TModel> Build { get;      }
    }
}
