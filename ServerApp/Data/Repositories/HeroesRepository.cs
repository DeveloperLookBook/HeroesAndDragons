using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Repositories
{
    public class HeroesRepository : Repository<IHero>
    {
        private void TryToAttachWeapon(IEnumerable<IHero> models)
        {
            foreach (var model in models)
            {
                this.TryToAttachWeapon(model.Weapon);
            }
        }


        public override void Add   (IHero              model )
        {
            this.TryToAttachWeapon(model.Weapon);

            base.Add(model);
        }
        public override void Add   (IEnumerable<IHero> models)
        {
            this.TryToAttachWeapon(models);

            base.Add(models);
        }
        public override void Update(IHero              model )
        {
            var weapon = model.Weapon;

            this.TryToAttachWeapon(weapon);

            base.Update(model);
        }
        public override void Update(IEnumerable<IHero> models)
        {
            this.TryToAttachWeapon(models);

            base.Update(models);
        }


        #region SINGLETON

        private static HeroesRepository Instance { get; set; }
        private static object           Lock     => new object();

        private HeroesRepository(GameDbContext context) : base(context)
        {

        }

        public static HeroesRepository Create(GameDbContext context)
        {
            lock (Lock)
            {
                return Instance = ((Instance is null) ? new HeroesRepository(context) : Instance);
            }
        }

        #endregion  
    }
}
