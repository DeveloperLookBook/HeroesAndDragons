using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Data.Requests;
using ServerApp.Models;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class IQueryableExtencion
    {

        #region MODEL REQUESTS
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
        private static IQueryable<TModel>        OrderByCreationDateAsc<TModel>(this IQueryable<TModel> queryable) where TModel : class, IModel
        {
            return (from m in queryable orderby m.Created ascending select m);
        }
        private static IQueryable<TModel>        OrderByCreationDateAsc<TModel>(this IQueryable<TModel> queryable, out IEnumerable<TModel> models) where TModel : class, IModel
        {
            return queryable.OrderByCreationDateAsc().RetriveEnumerable(out models);
        }
        private static IQueryable<TModel>        OrderByCreationDateDes<TModel>(this IQueryable<TModel> queryable) where TModel : class, IModel
        {
            return (from m in queryable orderby m.Created descending select m);
        }
        private static IQueryable<TModel>        OrderByCreationDateDes<TModel>(this IQueryable<TModel> queryable, out IEnumerable<TModel> models) where TModel : class, IModel
        {
            return queryable.OrderByCreationDateDes().RetriveEnumerable(out models);
        }
        public  static IQueryable<TModel>        OrderByCreationDate   <TModel>(this IQueryable<TModel> queryable, OrderingStrategy option) where TModel : class, IModel
        {
            switch (option)
            {
                case OrderingStrategy.Ascending : return queryable.OrderByCreationDateAsc();
                case OrderingStrategy.Descending: return queryable.OrderByCreationDateDes();

                default: throw new ArgumentException("Option doesn't exist.", nameof(option));
            }
        }
        public  static IQueryable<TModel>        OrderByCreationDate   <TModel>(this IQueryable<TModel> queryable, OrderingStrategy option, out IEnumerable<TModel>       models) where TModel : class, IModel
        {
            return queryable.OrderByCreationDate(option).RetriveEnumerable(out models);
        }
        public  static IQueryable<TModel>        OrderByCreationDate   <TModel>(this IQueryable<TModel> queryable, OrderingStrategy option, out Task<IEnumerable<TModel>> models) where TModel : class, IModel
        {
            return queryable.OrderByCreationDate(option).RetriveEnumerableAsync(out models);
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
        private static IQueryable<TCharacter> OrderByNameAsc       <TCharacter>(this IQueryable<TCharacter> queryable) where TCharacter : class, ICharacter
        {
            return (from c in queryable orderby c.Name ascending select c);
        }
        private static IQueryable<TCharacter> OrderByNameAsc       <TCharacter>(this IQueryable<TCharacter> queryable, out IEnumerable<TCharacter> characters) where TCharacter : class, ICharacter
        {
            return queryable.OrderByNameAsc().RetriveEnumerable(out characters);
        }
        private static IQueryable<TCharacter> OrderByNameDes       <TCharacter>(this IQueryable<TCharacter> queryable) where TCharacter : class, ICharacter
        {
            return (from c in queryable orderby c.Name descending select c);
        }
        private static IQueryable<TCharacter> OrderByNameDes       <TCharacter>(this IQueryable<TCharacter> queryable, out IEnumerable<TCharacter> characters) where TCharacter : class, ICharacter
        {
            return queryable.OrderByNameDes().RetriveEnumerable(out characters);
        }
        public  static IQueryable<TCharacter> OrderByName          <TCharacter>(this IQueryable<TCharacter> queryable, OrderingStrategy option) where TCharacter : class, ICharacter
        {
            switch (option)
            {
                case OrderingStrategy.Ascending : return queryable.OrderByNameAsc();
                case OrderingStrategy.Descending: return queryable.OrderByNameDes();

                default: throw new ArgumentException("Option doesn't exist.", nameof(option));
            }
        }
        public  static IQueryable<TCharacter> OrderByName          <TCharacter>(this IQueryable<TCharacter> queryable, OrderingStrategy option, out IEnumerable<TCharacter> characters) where TCharacter : class, ICharacter
        {
            return queryable.OrderByName(option).RetriveEnumerable(out characters);
        }
        public  static IQueryable<TCharacter> OrderByName          <TCharacter>(this IQueryable<TCharacter> queryable, OrderingStrategy option, out Task<IEnumerable<TCharacter>> characters) where TCharacter : class, ICharacter
        {
            return queryable.OrderByName(option).RetriveEnumerableAsync(out characters);
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
        


        #region DRAGON REQUESTS        

        public  static IQueryable<TDragon> Alive           <TDragon>(this IQueryable<TDragon> queryable) where TDragon : class, IDragon
        {
            return (from d in queryable where (d.Health > 0) select d);
        }
        public  static IQueryable<TDragon> Alive           <TDragon>(this IQueryable<TDragon> queryable, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.Alive().RetriveEnumerable(out dragons);
        }
        public  static IQueryable<TDragon> Alive           <TDragon>(this IQueryable<TDragon> queryable, out Task<IEnumerable<TDragon>> dragons) where TDragon : class, IDragon
        {
            return queryable.Alive().RetriveEnumerableAsync(out dragons);
        }
        public  static IQueryable<TDragon> Dead            <TDragon>(this IQueryable<TDragon> queryable) where TDragon : class, IDragon
        {
            return (from d in queryable where (d.Health <= 0) select d);
        }
        public  static IQueryable<TDragon> Dead            <TDragon>(this IQueryable<TDragon> queryable, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.Dead().RetriveEnumerable(out dragons);
        }
        public  static IQueryable<TDragon> Dead            <TDragon>(this IQueryable<TDragon> queryable, out Task<IEnumerable<TDragon>> dragons) where TDragon : class, IDragon
        {
            return queryable.Dead().RetriveEnumerableAsync(out dragons);
        }

        private static IQueryable<TDragon> OrderByHealthAsc<TDragon>(this IQueryable<TDragon> queryable) where TDragon : class, IDragon
        {
            return (from d in queryable orderby d.Health ascending select d);
        }
        private static IQueryable<TDragon> OrderByHealthAsc<TDragon>(this IQueryable<TDragon> queryable, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.OrderByHealthAsc().RetriveEnumerable(out dragons);
        }
        private static IQueryable<TDragon> OrderByHealthDes<TDragon>(this IQueryable<TDragon> queryable) where TDragon : class, IDragon
        {
            return (from d in queryable orderby d.Health descending select d);
        }
        private static IQueryable<TDragon> OrderByHealthDes<TDragon>(this IQueryable<TDragon> queryable, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.OrderByHealthDes().RetriveEnumerable(out dragons);
        }
        public  static IQueryable<TDragon> OrderByHealth   <TDragon>(this IQueryable<TDragon> queryable, OrderingStrategy strategy) where TDragon : class, IDragon
        {
            switch (strategy)
            {
                case OrderingStrategy.Ascending : return queryable.OrderByHealthAsc();
                case OrderingStrategy.Descending: return queryable.OrderByHealthDes();

                default: throw new ArgumentException("Option doesn't exist.", nameof(strategy));
            }
        }
        public  static IQueryable<TDragon> OrderByHealth   <TDragon>(this IQueryable<TDragon> queryable, OrderingStrategy strategy, out IEnumerable<TDragon> dragons) where TDragon : class, IDragon
        {
            return queryable.OrderByHealth(strategy).RetriveEnumerable(out dragons);
        }
        public  static IQueryable<TDragon> OrderByHealth   <TDragon>(this IQueryable<TDragon> queryable, OrderingStrategy strategy, out Task<IEnumerable<TDragon>> dragons) where TDragon : class, IDragon
        {
            return queryable.OrderByHealth(strategy).RetriveEnumerableAsync(out dragons);
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
        private static IQueryable<TWeapon> OrderedByStrengthAsc     <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return (from w in queryable orderby w.Strength ascending select w);
        }
        private static IQueryable<TWeapon> OrderedByStrengthAsc     <TWeapon>(this IQueryable<TWeapon> queryable, out IEnumerable<TWeapon> weapons) where TWeapon : class, IWeapon
        {
            return queryable.OrderedByStrengthAsc().RetriveEnumerable(out weapons);
        }
        private static IQueryable<TWeapon> OrderedByStrengthDes     <TWeapon>(this IQueryable<TWeapon> queryable) where TWeapon : class, IWeapon
        {
            return (from w in queryable orderby w.Strength descending select w);
        }
        private static IQueryable<TWeapon> OrderedByStrengthDes     <TWeapon>(this IQueryable<TWeapon> queryable, out IEnumerable<TWeapon> weapons) where TWeapon : class, IWeapon
        {
            return queryable.OrderedByStrengthDes().RetriveEnumerable(out weapons);
        }
        public  static IQueryable<TWeapon> OrderedByStrength        <TWeapon>(this IQueryable<TWeapon> queryable, OrderingStrategy strategy) where TWeapon : class, IWeapon
        {
            switch (strategy)
            {
                case OrderingStrategy.Ascending : return queryable.OrderedByStrengthAsc();
                case OrderingStrategy.Descending: return queryable.OrderedByStrengthDes();

                default: throw new ArgumentException("Ordering strategy doesn't exist.", nameof(strategy));
            }
        }
        public  static IQueryable<TWeapon> OrderedByStrength        <TWeapon>(this IQueryable<TWeapon> queryable, OrderingStrategy strategy, out IEnumerable<TWeapon> weapons) where TWeapon : class, IWeapon
        {
            return queryable.OrderedByStrength(strategy).RetriveEnumerable(out weapons);
        }
        public  static IQueryable<TWeapon> OrderedByStrength        <TWeapon>(this IQueryable<TWeapon> queryable, OrderingStrategy strategy, out Task<IEnumerable<TWeapon>> weapons) where TWeapon : class, IWeapon
        {
            return queryable.OrderedByStrength(strategy).RetriveEnumerableAsync(out weapons);
        }

        #endregion
    }
}
