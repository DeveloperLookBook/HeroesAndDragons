using ServerApp.Data.Repositories;
using ServerApp.Models;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.UnitOfWorks
{
    public class GameContext : IDisposable, IGameContext
    {
        #region PROPERTIES

        private GameDbContext        Context  { get;      }        
        public  IRepository<IHero>   Heroes   { get;      }
        public  IRepository<IDragon> Dragons  { get;      }
        public  IRepository<IHit>    Hits     { get;      }
        public  IRepository<IWeapon> Weapon   { get;      }
        private bool                 Disposed { get; set; } = false;

        #endregion


        #region CONSTRUCTORS

        public GameContext(GameDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.Heroes  = new HeroesRepository (context);
            this.Dragons = new DragonsRepository(context);
            this.Hits    = new HitsRepository   (context);
            this.Weapon  = new WeaponsRepository(context);
        }

        #endregion


        #region NETHODS

        public IRepository<TModel> Repository<TModel>() where TModel : class, IModel
        {
            if (typeof(IRepository<TModel>).Name == typeof(IRepository<IHero>  ).Name) return (IRepository<TModel>)this.Heroes;
            if (typeof(IRepository<TModel>).Name == typeof(IRepository<IDragon>).Name) return (IRepository<TModel>)this.Dragons;
            if (typeof(IRepository<TModel>).Name == typeof(IRepository<IHit>   ).Name) return (IRepository<TModel>)this.Hits;
            if (typeof(IRepository<TModel>).Name == typeof(IRepository<IWeapon>).Name) return (IRepository<TModel>)this.Hits;

            throw new Exception("Selected generic type of the repository doesn't exist.");
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }

                this.Disposed = true;
            }
        }
        public         void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        

        #endregion
    }
}
