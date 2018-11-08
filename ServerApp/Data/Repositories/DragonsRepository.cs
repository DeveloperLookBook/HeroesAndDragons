using ServerApp.Models.Characters.Dragons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class DragonsRepository : Repository<IDragon>
    {
        #region SINGLETON

        private static DragonsRepository Instance { get; set; }
        private static object            Lock      => new object();

        private DragonsRepository(GameDbContext context) : base(context)
        {

        }

        public static DragonsRepository Create(GameDbContext context)
        {
            lock (Lock)
            {
                return Instance = ((Instance is null) ? new DragonsRepository(context) : Instance);
            }
        }

        #endregion        
    }
}
