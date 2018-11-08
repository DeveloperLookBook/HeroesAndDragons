using ServerApp.Models;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public interface IRepositoryCreator
    {
        HeroesRepository  Heroes ();
        DragonsRepository Dragons();
        HitsRepository    Hits   ();
    }


    public delegate TRepository RepositorySelectorFunc<TRepository>(IRepositoryCreator creator)
        where TRepository : IRepository;


    public class RepositoryFactory : IDisposable, IRepositoryFactory
    {
        #region LOCAL CLASS

        private class Creator : IRepositoryCreator, IDisposable
        {
            private GameDbContext Context  { get; }
            public  bool          Disposed { get; set; } = false;


            public Creator(GameDbContext context) => this.Context = context;


            public HeroesRepository  Heroes () => HeroesRepository .Create(this.Context);
            public DragonsRepository Dragons() => DragonsRepository.Create(this.Context);
            public HitsRepository    Hits   () => HitsRepository   .Create(this.Context);

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
        }

        #endregion


        #region PROPERTIES

        static private Creator InstanceCreator { get; set; }
               public  bool    Disposed        { get; set; } = false;

        #endregion


        #region CONSTRUCTORS

        public RepositoryFactory(GameDbContext context)
        {
            if (context is null) { throw new ArgumentNullException(nameof(context)); }

            InstanceCreator = new Creator(context); 
        }

        #endregion


        #region NETHODS

        public TRepocitory  Create<TRepocitory>(RepositorySelectorFunc<TRepocitory> selector)
            where TRepocitory : class, IRepository
        {
            return selector(InstanceCreator);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    InstanceCreator.Dispose(disposing);
                    InstanceCreator = null;
                }

                this.Disposed = true;
            }
        }
        public         void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }    
}
