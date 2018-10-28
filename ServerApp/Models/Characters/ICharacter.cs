using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters
{
    public interface ICharacter : IModel
    {
        string Name   { get; set; }
    }

    public interface ICharacter<TId> : IModel<TId>, ICharacter where TId : IComparable<TId>
    {

    }
}
