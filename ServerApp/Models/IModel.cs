using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public interface IModel
    {
        Object   Id      { get; }
        DateTime Created { get; }
    }

    public interface IModel<out TId>: IModel where TId : IComparable<TId>
    {
        new TId  Id      { get; }
    }
}
