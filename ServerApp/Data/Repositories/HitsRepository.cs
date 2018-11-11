using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class HitsRepository : Repository<IHit>
    {

        /// <summary>
        /// Attaches weapon instances to the DB context if it's already exists in DB.
        /// </summary>
        /// <param name="models"></param>
        private void TryToAttachWeapon(IEnumerable<IHit> models)
        {
            foreach (var model in models)
            {
                this.TryToAttachWeapon(model.Weapon);
            }
        }


        public override void Add   (IHit              model )
        {
            this.TryToAttachWeapon(model.Weapon);

            base.Add(model);
        }
        public override void Add   (IEnumerable<IHit> models)
        {
            this.TryToAttachWeapon(models);

            base.Add(models);
        }
        public override void Update(IHit              model )
        {
            this.TryToAttachWeapon(model.Weapon);

            base.Update(model);
        }
        public override void Update(IEnumerable<IHit> models)
        {
            this.TryToAttachWeapon(models);

            base.Update(models);
        }


        #region SINGLETON

        private static HitsRepository Instance { get; set; }
        private static object         Lock => new object();

        private HitsRepository(GameDbContext context) : base(context)
        {

        }

        public static HitsRepository Create(GameDbContext context)
        {
            lock (Lock)
            {
                return Instance = ((Instance is null) ? new HitsRepository(context) : Instance);
            }
        }

        #endregion  
    }
}
