using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    [NotMapped]
    public abstract class Model<TId> : IModel<TId> where TId : IComparable<TId>
    {
        #region FIELDS

        TId      _id;
        DateTime _created = DateTime.Now;

        #endregion        

        #region PROPERTIES

        public TId      Id        { get => this._id; protected set => this._id = value; }
               object   IModel.Id => this.Id;
        public DateTime Created   => this._created;

        #endregion
    }
}
