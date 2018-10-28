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

        private TId      _id;
        private DateTime _created;

        #endregion        

        #region PROPERTIES

        public TId      Id        => this._id;
               object   IModel.Id => this._id;
        public DateTime Created   => this._created;

        #endregion


        #region CONSTRUCTORS

        protected Model(DateTime created) => this._created = created;

        #endregion
    }
}
