using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Data.Requests;
using ServerApp.Models;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using ServerApp.Paginations;
using ServerApp.ViewModels;
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

        private static IQueryable<TModel>        OrderByAscending <TModel, TKey>(this IQueryable<TModel> queryable, Expression<Func<TModel, TKey>> keySelector)
            where TModel : IModel
        {
            return queryable.OrderBy(keySelector);
        }        
        public  static IQueryable<TModel>        OrderBy          <TModel, TKey>(this IQueryable<TModel> queryable, Expression<Func<TModel, TKey>> keySelector, OrderingStrategy ordering = OrderingStrategy.Ascending) where TModel : IModel
        {
            switch (ordering)
            {
                case OrderingStrategy.Ascending : return queryable.OrderByAscending(keySelector);
                case OrderingStrategy.Descending: return queryable.OrderByDescending(keySelector);
                default                         : return queryable.OrderByDescending(keySelector);
            }
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
        private static IQueryable<TCharacter> NameStrictlyLessThan <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.NameLessThan(name, ignoreCase).RetriveEnumerable(out characters);
        }
        public  static IQueryable<TCharacter> FindByName           <TCharacter>(this IQueryable<TCharacter> queryable, string name, SearchStrategy strategy = SearchStrategy.Equal, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            switch (strategy)
            {
                case SearchStrategy.Сomprehensive:

                    var options = (ignoreCase) ? RegexOptions.Multiline | RegexOptions.IgnoreCase : RegexOptions.Multiline;

                    return from c in queryable
                           where ( (Regex.IsMatch(c.Name, $@"\A{  name.Escape()}", options)) || 
                                   (Regex.IsMatch(name  , $@"\A{c.Name.Escape()}", options)) )
                           select c;

                case SearchStrategy.StratsWith: return queryable.NameStartsWith (name, ignoreCase);
                case SearchStrategy.Greater   : return queryable.NameGreaterThan(name, ignoreCase);
                case SearchStrategy.Less      : return queryable.NameLessThan   (name, ignoreCase);
                case SearchStrategy.Equal     : return queryable.NameEqualTo    (name, ignoreCase);

                default: throw new ArgumentException("Selected strategy doesn't exist.", nameof(strategy));
            }
        }                                                       
        public  static IQueryable<TCharacter> FindByName           <TCharacter>(this IQueryable<TCharacter> queryable, string name, out IEnumerable<TCharacter> characters, SearchStrategy strategy = SearchStrategy.Equal, bool ignoreCase = false) where TCharacter : class, ICharacter
        {
            return queryable.FindByName(name, strategy, ignoreCase).RetriveEnumerable(out characters);
        }       
        public  static IQueryable<TCharacter> FindByName           <TCharacter>(this IQueryable<TCharacter> queryable, string name, out Task<IEnumerable<TCharacter>> characters, SearchStrategy strategy = SearchStrategy.Equal, bool ignoreCase = false) where TCharacter : class, ICharacter
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

        public  static View<HeroViewModel> ToHeroModelView<THero>(this IQueryable<THero> queryable, int pageNumber, int pageSize = 15, int maxPageSize = 100, int minPageSize = 10) where THero : class, IHero
        {
            var @params = new ViewParams(queryable.Count(), pageNumber, maxPageSize, minPageSize, pageSize);

            var models = (from h in queryable.Skip(@params.Skip()).Take(@params.PageSize)
                           select new HeroViewModel
                           {
                               Id = h.Id,
                               Name = h.Name,
                               Created = h.Created,
                               Weapon = new WeaponViewModel()
                               {
                                   Id = h.Weapon.Id,
                                   Name = h.Weapon.Name,
                                   Strength = h.Weapon.Strength
                               }
                           }).ToList();

            return new View<HeroViewModel>(models, @params);
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
