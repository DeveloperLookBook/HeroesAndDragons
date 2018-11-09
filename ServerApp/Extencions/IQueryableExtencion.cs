using ServerApp.Data.Services.Helpers;
using ServerApp.Models;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using ServerApp.Paginations;
using ServerApp.ViewModels;
using ServerApp.ViewModels.Characters;
using ServerApp.ViewModels.Characters.Dragons;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class IQueryableExtencion
    {

        #region MODEL REQUESTS

        public  static IQueryable<TModel>        OrderByAsc            <TModel, TKey>(this IQueryable<TModel> queryable, Expression<Func<TModel, TKey>> keySelector) where TModel : IModel
        {
            return queryable.OrderBy(keySelector);
        }        
        public  static IQueryable<TModel>        OrderByDes            <TModel, TKey>(this IQueryable<TModel> queryable, Expression<Func<TModel, TKey>> keySelector) where TModel : IModel
        {
            return queryable.OrderByDescending(keySelector);
        }


        private static Task<IEnumerable<TModel>> ToEnumerableAsync     <TModel>(this IQueryable<TModel> queryable)
        {
            return Task.Run(() => queryable.AsEnumerable());
        }
        private static IQueryable<TModel>        RetriveEnumerable     <TModel>(this IQueryable<TModel> queryable, out IEnumerable<TModel>       models) where TModel : class, IModel
        {
            models = queryable.AsEnumerable();
            return queryable;
        }                                                                
        private static IQueryable<TModel>        RetriveEnumerableAsync<TModel>(this IQueryable<TModel> queryable, out Task<IEnumerable<TModel>> models) where TModel : class, IModel
        {
            models = Task.Run(() => queryable.AsEnumerable());

            return queryable;
        }                                                                                                                 
        public  static IQueryable<TModel>        CreatedAt             <TModel>(this IQueryable<TModel> queryable, DateTime date) where TModel : class, IModel
        {
            return (from m in queryable where m.Created == date select m);
        }
        public  static int                       Count                 <TModel>(this IQueryable<TModel> queryable, DateTime date) where TModel : class, IModel
        {            
            return (from m in queryable select m).Count();
        }
        public  static IQueryable<TModel>        Count                 <TModel>(this IQueryable<TModel> queryable, DateTime date, out int count) where TModel : class, IModel
        {
            count = queryable.Count();

            return queryable;
        }        
        public  static TModel                    FindById              <TModel>(this IQueryable<TModel> queryable, int id) where TModel : class, IModel<int>
        {
            return (from c in queryable where (c.Id == id) select c).FirstOrDefault();
        }
        public  static async Task<TModel>        FindByIdAsync         <TModel>(this IQueryable<TModel> queryable, int id) where TModel : class, IModel<int>
        {
            return await Task.Run(() => (from c in queryable where (c.Id == id) select c).FirstOrDefault());
        }
        public  static bool                      HaveIdEqualTo         <TModel>(this IQueryable<TModel> queryable, int id, out IModel<int> firstOrDefaultModel) where TModel : class, IModel<int>
        {
            firstOrDefaultModel = queryable.FindById(id);

            return (firstOrDefaultModel is null) ? false : true;
        }
        public  static async Task<bool>          HaveIdEqualToAsync    <TModel>(this IQueryable<TModel> queryable, int id) where TModel : class, IModel<int>
        {
            IModel<int> model = await queryable.FindByIdAsync(id);

            return (model is null) ? false : true;
        }
        
        #endregion



        #region CHARACTER REQUESTS        

        private static IQueryable<TCharacter> NameEqualTo          <TCharacter>(this IQueryable<TCharacter> queryable, string name, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return (from c in queryable where (string.Compare(c.Name, name, ignoreCase) == 0) select c);
        }
        private static IQueryable<TCharacter> NameEqualTo          <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.NameEqualTo(name, ignoreCase).RetriveEnumerable(out characters);
        }
        private static IQueryable<TCharacter> NameStartsWith       <TCharacter>(this IQueryable<TCharacter> queryable, string name, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return (from c in queryable where c.Name.StartsWith(name, ignoreCase, Thread.CurrentThread.CurrentCulture) select c);
        }
        private static IQueryable<TCharacter> NameStartsWith       <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.NameStartsWith(name, ignoreCase).RetriveEnumerable(out characters);
        }
        private static IQueryable<TCharacter> NameGreaterThan      <TCharacter>(this IQueryable<TCharacter> queryable, string name, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return (from c in queryable where (string.Compare(c.Name, name, ignoreCase) > 0) select c);
        }
        private static IQueryable<TCharacter> NameGreaterThan      <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.NameGreaterThan(name, ignoreCase).RetriveEnumerable(out characters);
        }
        private static IQueryable<TCharacter> NameLessThan         <TCharacter>(this IQueryable<TCharacter> queryable, string name, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return (from c in queryable where (string.Compare(c.Name, name, ignoreCase) < 0) select c);
        }
        private static IQueryable<TCharacter> NameLessThan         <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.NameLessThan(name, ignoreCase).RetriveEnumerable(out characters);
        }

        private static IQueryable<TCharacter> NameLessGreaterOrEqualTo<TCharacter>(this IQueryable<TCharacter> queryable, string name, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return (from c in queryable
                    where (string.Compare(c.Name, name, ignoreCase) <  0) || 
                          (string.Compare(c.Name, name, ignoreCase) >  0) ||
                          (string.Compare(c.Name, name, ignoreCase) == 0)
                    select c);
        }

        public static IQueryable<TCharacter>  FindByName           <TCharacter>(this IQueryable<TCharacter> queryable, string name, SearchType strategy = SearchType.AllMatches, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            switch (strategy)
            {
                case SearchType.AllMatches   : return queryable.NameLessGreaterOrEqualTo(name, ignoreCase);                
                case SearchType.StratsWith   : return queryable.NameStartsWith          (name, ignoreCase);
                case SearchType.Greater      : return queryable.NameGreaterThan         (name, ignoreCase);
                case SearchType.Less         : return queryable.NameLessThan            (name, ignoreCase);
                case SearchType.Equal        : return queryable.NameEqualTo             (name, ignoreCase);
                case SearchType.Сomprehensive:

                    var options = (ignoreCase) ? RegexOptions.Multiline | RegexOptions.IgnoreCase : RegexOptions.Multiline;

                    return (from c in queryable
                            where ((Regex.IsMatch(c.Name, $@"\A{  name.Escape()}\z", options)) ||
                                   (Regex.IsMatch(  name, $@"\A{c.Name.Escape()}\z", options)))
                            select c);

                default: throw new ArgumentException("Selected strategy doesn't exist.", nameof(strategy));
            }
        }                                                       
        public  static IQueryable<TCharacter> FindByName           <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, SearchType strategy = SearchType.Equal, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.FindByName(name, strategy, ignoreCase).RetriveEnumerable(out characters);
        }       
        public  static IQueryable<TCharacter> FindByName           <TCharacter>(this IQueryable<TCharacter> queryable, string name, out Task<IEnumerable<TCharacter>> characters, SearchType strategy = SearchType.Equal, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.FindByName(name, strategy, ignoreCase).RetriveEnumerableAsync(out characters);
        }                                                                                 
        public  static bool                   HaveNamesEqualTo     <TCharacter>(this IQueryable<TCharacter> queryable, string name) where TCharacter : class, ICharacter
        {
            TCharacter character = queryable.NameEqualTo(name).FirstOrDefault();

            return (character is null) ? false : true;
        }
        public  static Task<bool>             HaveNamesEqualToAsync<TCharacter>(this IQueryable<TCharacter> queryable, string name) where TCharacter : class, ICharacter
        {
            return Task.Run(() =>
            {
                TCharacter character = queryable.NameEqualTo(name).FirstOrDefault();

                return (character is null) ? false : true;
            });            
        }
        public  static bool                   HaveNamesEqualTo     <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters) where TCharacter : class, ICharacter
        {
            TCharacter character = queryable.NameEqualTo(name).RetriveEnumerable(out characters).FirstOrDefault();

            return queryable.HaveNamesEqualTo(name);
        }

        #endregion



        #region HEROE REQUESTS

        public static IQueryable<THero>   FilterBy       <THero>(this IQueryable<THero> queryable, HeroesFilter filter) 
            where THero : class, IHero
        {
            var heroes = queryable;

            switch (filter)
            {
                case HeroesFilter.All: return heroes;

                default:               return heroes;
            }
        }
        public static IQueryable<THero>   OrderBy        <THero>(this IQueryable<THero> queryable, HeroesOrdering ordering, OrderType order)
            where THero : class, IHero
        {
            var heroes = queryable;

            switch (ordering)
            {
                case HeroesOrdering.ByName           when order == OrderType.Ascending : return heroes.OrderByAsc(h => h.Name           );
                case HeroesOrdering.ByName           when order == OrderType.Descending: return heroes.OrderByDes(h => h.Name           );
                case HeroesOrdering.ByCreated        when order == OrderType.Ascending : return heroes.OrderByAsc(h => h.Created        );
                case HeroesOrdering.ByCreated        when order == OrderType.Descending: return heroes.OrderByDes(h => h.Created        );
                case HeroesOrdering.ByWeaponName     when order == OrderType.Ascending : return heroes.OrderByAsc(h => h.Weapon.Name    );
                case HeroesOrdering.ByWeaponName     when order == OrderType.Descending: return heroes.OrderByDes(h => h.Weapon.Name    );
                case HeroesOrdering.ByWeaponStrength when order == OrderType.Ascending : return heroes.OrderByAsc(h => h.Weapon.Strength);
                case HeroesOrdering.ByWeaponStrength when order == OrderType.Descending: return heroes.OrderByDes(h => h.Weapon.Strength);

                default:                                                                 return heroes.OrderByDes(h => h.Created        );
            }
        }
        public static View<HeroViewModel> ToHeroModelView<THero>(this IQueryable<THero> queryable, int pageNumber, int pageSize = 15, int maxPageSize = 100, int minPageSize = 10) 
            where THero : class, IHero
        {
            var @params = new ViewParams(queryable.Count(), pageNumber, maxPageSize, minPageSize, pageSize);            

            var models = (from h in queryable.Skip(@params.Skip()).Take(@params.PageSize)
                           select new HeroViewModel
                           {
                               Id      = h.Id,
                               Name    = h.Name,
                               Created = h.Created,
                               Weapon  = new WeaponViewModel()
                               {
                                   Id       = h.Weapon.Id,
                                   Name     = h.Weapon.Name,
                                   Strength = h.Weapon.Strength
                               }
                           }).ToList();

            return new View<HeroViewModel>(models, @params);
        }

        #endregion


        #region HITS REQUESTS

        public static IQueryable<THit>   FilterBy<THit>(this IQueryable<THit> queryable, HeroHitsFilter filter) where THit : class, IHit
        {
            var hits = queryable;

            switch (filter)
            {
                case HeroHitsFilter.All: return hits;

                default:                 return hits;
            }
        }
        
        public static IQueryable<THit>   OrderBy        <THit>(this IQueryable<THit> queryable, HitsOrdering ordering, OrderType order) 
            where THit : class, IHit
        {
            var hits = queryable;

            switch (ordering)
            {
                case HitsOrdering.ByTargetName     when OrderType.Ascending  == order: return hits.OrderByAsc(h => h.Target.Name    );
                case HitsOrdering.ByTargetName     when OrderType.Descending == order: return hits.OrderByDes(h => h.Target.Name    );
                case HitsOrdering.BySourceName     when OrderType.Ascending  == order: return hits.OrderByAsc(h => h.Source.Name    );
                case HitsOrdering.BySourceName     when OrderType.Descending == order: return hits.OrderByDes(h => h.Source.Name    );
                case HitsOrdering.ByWeaponName     when OrderType.Ascending  == order: return hits.OrderByAsc(h => h.Weapon.Name    );
                case HitsOrdering.ByWeaponName     when OrderType.Descending == order: return hits.OrderByDes(h => h.Weapon.Name    );
                case HitsOrdering.ByWeaponStrength when OrderType.Ascending  == order: return hits.OrderByAsc(h => h.Weapon.Strength);
                case HitsOrdering.ByWeaponStrength when OrderType.Descending == order: return hits.OrderByDes(h => h.Weapon.Strength);
                case HitsOrdering.ByStrength       when OrderType.Ascending  == order: return hits.OrderByAsc(h => h.Strength       );
                case HitsOrdering.ByStrength       when OrderType.Descending == order: return hits.OrderByDes(h => h.Strength       );
                case HitsOrdering.ByCreated        when OrderType.Ascending  == order: return hits.OrderByAsc(h => h.Created        );
                case HitsOrdering.ByCreated        when OrderType.Descending == order: return hits.OrderByDes(h => h.Created        );

                default:                                                               return hits.OrderByDes(h => h.Created        );
            }
        }

        public static View<HeroHitViewModel> ToHeroHitsModelView<THit>(this IQueryable<THit> queryable, int pageNumber, int pageSize = 15, int maxPageSize = 100, int minPageSize = 10) 
            where THit : class, IHit
        {
            var @params = new ViewParams(queryable.Count(), pageNumber, maxPageSize, minPageSize, pageSize);

            var models = (from h in queryable.Skip(@params.Skip()).Take(@params.PageSize)
                          select new HeroHitViewModel
                          {
                              Id = h.Id,
                              Target = new CharacterViewModel()
                              {
                                  Id   = h.Target.Id,
                                  Name = h.Target.Name,
                                  Type = h.Target.GetType().Name,
                              },
                              Weapon = new WeaponViewModel()
                              {
                                  Id       = h.Weapon.Id,
                                  Name     = h.Weapon.Name,
                                  Strength = h.Weapon.Strength,
                              },
                              Strength = h.Strength,
                              Created  = h.Created,
                          }).ToList();

            return new View<HeroHitViewModel>(models, @params);
        }

        #endregion


        #region DRAGON REQUESTS        

        public  static IQueryable<TDragon> Alive             <TDragon>(this IQueryable<TDragon> queryable) where TDragon : class, IDragon
        {
            return (from d in queryable where (d.Health > 0) select d);
        }
        public  static IQueryable<TDragon> Alive             <TDragon>(this IQueryable<TDragon> queryable, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.Alive().RetriveEnumerable(out dragons);
        }
        public  static IQueryable<TDragon> Alive             <TDragon>(this IQueryable<TDragon> queryable, out Task<IEnumerable<TDragon>> dragons) where TDragon : class, IDragon
        {
            return queryable.Alive().RetriveEnumerableAsync(out dragons);
        }
        public  static IQueryable<TDragon> Dead              <TDragon>(this IQueryable<TDragon> queryable) where TDragon : class, IDragon
        {
            return (from d in queryable where (d.Health <= 0) select d);
        }
        public  static IQueryable<TDragon> Dead              <TDragon>(this IQueryable<TDragon> queryable, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.Dead().RetriveEnumerable(out dragons);
        }
        public  static IQueryable<TDragon> Dead              <TDragon>(this IQueryable<TDragon> queryable, out Task<IEnumerable<TDragon>> dragons) where TDragon : class, IDragon
        {
            return queryable.Dead().RetriveEnumerableAsync(out dragons);
        }


        public static IQueryable<TDragon>  FilterBy         <TDragon>(this IQueryable<TDragon> queryable, DragonsFilter filter) 
            where TDragon : class, IDragon
        {
            var dragons = queryable;

            switch (filter)
            {
                case DragonsFilter.All  : return dragons;
                case DragonsFilter.Alive: return dragons.Alive();
                case DragonsFilter.Dead : return dragons.Dead() ;

                default:                  return dragons;
            }
        }
        public static IQueryable<TDragon>  OrderBy          <TDragon>(this IQueryable<TDragon> queryable, DragonsOrdering ordering, OrderType order) 
            where TDragon : class, IDragon
        {
            var dragons = queryable;
            
            switch (ordering)
            {
                case DragonsOrdering.ByName    when (order == OrderType.Ascending ): return dragons.OrderByAsc(d => d.Name   );
                case DragonsOrdering.ByName    when (order == OrderType.Descending): return dragons.OrderByDes(d => d.Name   );
                case DragonsOrdering.ByHealth  when (order == OrderType.Ascending ): return dragons.OrderByAsc(d => d.Health );
                case DragonsOrdering.ByHealth  when (order == OrderType.Descending): return dragons.OrderByDes(d => d.Health );
                case DragonsOrdering.ByCreated when (order == OrderType.Ascending ): return dragons.OrderByAsc(d => d.Created);
                case DragonsOrdering.ByCreated when (order == OrderType.Descending): return dragons.OrderByDes(d => d.Created);

                default:                                                             return dragons.OrderByDes(h => h.Created);
            } 
        }
        public static View<DragonViewModel> ToDragonModelView<TDragon>(this IQueryable<TDragon> queryable, int pageNumber, int pageSize = 15, int maxPageSize = 100, int minPageSize = 10) where TDragon : class, IDragon
        {
            var @params = new ViewParams(queryable.Count(), pageNumber, maxPageSize, minPageSize, pageSize);

            var models = (from d in queryable.Skip(@params.Skip()).Take(@params.PageSize)
                          select new DragonViewModel
                          {
                              Id = d.Id,
                              Name = d.Name,
                              Health = d.Health,
                              Created = d.Created,
                          }).ToList();

            return new View<DragonViewModel>(models, @params);
        }        

        #endregion



        #region WEAPON REQUESTS        

        public  static TWeapon             FindByEnum               <TWeapon>(this IQueryable<TWeapon> queryable, WeaponType type) where TWeapon : class, IWeapon
        {
            return queryable.FindById((int)type);
        }
        public  static Task<TWeapon>       FindByEnumAsync          <TWeapon>(this IQueryable<TWeapon> queryable, WeaponType type) where TWeapon : class, IWeapon
        {
            return Task.Run(() => queryable.FindById((int)type));
        }
        public  static bool                FindByEnum               <TWeapon>(this IQueryable<TWeapon> queryable, WeaponType type, out TWeapon weapon) where TWeapon : class, IWeapon
        {
            weapon = queryable.FindByEnum(type);

            return (weapon is null) ? false : true;
        }
        public  static TWeapon             GetAxeSingleton          <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnum(WeaponType.Axe);
        }
        public  static Task<TWeapon>       GetAxeSingletonAsync     <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnumAsync(WeaponType.Axe);
        }
        public  static TWeapon             GetCrossbowSingleton     <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnum(WeaponType.Crossbow);
        }
        public  static Task<TWeapon>       GetCrossbowSingletonAsynk<TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnumAsync(WeaponType.Crossbow);
        }
        public  static TWeapon             GetKnifeSingleton        <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnum(WeaponType.Knife);
        }
        public  static Task<TWeapon>       GetKnifeSingletonAsynk   <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnumAsync(WeaponType.Knife);
        }
        public  static TWeapon             GetRapierSingleton       <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnum(WeaponType.Rapier);
        }
        public  static Task<TWeapon>       GetRapierSingletonAsync  <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnumAsync(WeaponType.Rapier);
        }
        public  static TWeapon             GetShieldSingleton       <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnum(WeaponType.Shield);
        }
        public  static Task<TWeapon>       GetShieldSingletonAsync  <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnumAsync(WeaponType.Shield);
        }
        public  static TWeapon             GetSwordSingleton        <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnum(WeaponType.Sword);
        }
        public  static Task<TWeapon>       GetSwordSingletonAsync   <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return queryable.FindByEnumAsync(WeaponType.Sword);
        }        

        #endregion
    }
}
