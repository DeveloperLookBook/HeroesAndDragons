using ServerApp.Data.Repositories;
using ServerApp.Models;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;

namespace ServerApp.Data.UnitOfWorks
{
    public interface IGameContext
    {
        IRepository<IDragon> Dragons { get; }
        IRepository<IHero>   Heroes  { get; }
        IRepository<IHit>    Hits    { get; }
        IRepository<IWeapon> Weapon  { get; }

        IRepository<TModel> Repository<TModel>() where TModel : class, IModel;

        void Dispose();
        void Dispose(bool disposing);
    }
}