using ServerApp.Data.Repositories;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;

namespace ServerApp.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<IDragon> Dragons { get; }
        IRepository<IHero> Heroes { get; }

        void Dispose();
        void Dispose(bool disposing);
    }
}