using ServerApp.Data.Repositories;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.UnitOfWorks
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region PROPERTIES

        private GameDbContext        Context  { get;      }        
        public  IRepository<IHero>   Heroes   { get;      }
        public  IRepository<IDragon> Dragons  { get;      }
        private bool                 Disposed { get; set; } = false;

        #endregion


        #region CONSTRUCTORS

        public UnitOfWork(GameDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.Heroes  = new HeroesRepository (context);
            this.Dragons = new DragonsRepository(context);
        }

        #endregion


        #region NETHODS

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
