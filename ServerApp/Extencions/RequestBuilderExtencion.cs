using ServerApp.Data;
using ServerApp.Data.Requests;
using ServerApp.Models;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class RequestBuilderExtencion
    {

        #region CHARACTER REQUESTS

        public static TCharacter WithNameEqualTo<TCharacter>(this RequestBuilder<TCharacter> builder, string value) where TCharacter : class, ICharacter
        {
            var query = from h in builder.GetQuery() where (h.Name == value) select h;

            var hero = query.FirstOrDefault();

            return hero;
        }

        public static bool WithNameEqualTo<TCharacter>(this RequestBuilder<TCharacter> builder, string value, out TCharacter hero) where TCharacter : class, ICharacter
        {
            hero = builder.WithNameEqualTo(value);

            return (hero is null) ? false : true;
        }

        public static RequestBuilder<TCharacter> WhoseNamesStartWith<TCharacter>(this RequestBuilder<TCharacter> builder, string value) where TCharacter : class, ICharacter
        {
            var query = from   h 
                        in     builder.GetQuery()
                        where  h.Name.IsMatch(value.Escape(), RegexOptions.Multiline | RegexOptions.IgnoreCase)
                        select h;

            return RequestBuilder<TCharacter>.CreateBuilder(query);
        }

        public static RequestBuilder<TCharacter> All<TCharacter>(this RequestBuilder<TCharacter> builder, string value) where TCharacter : class, ICharacter
        {
            return builder.Create
        }

        #endregion




            //#region HERO REQUESTS

            //public static THero WithNameEqualTo<THero>       (this RequestBuilder<THero> builder, string value) where THero : class, IHero
            //{
            //    return builder.WithNameEqualTo(value);
            //}

            //private static bool WithNameEqualTo<THero>(this RequestBuilder<THero> builder, string value, out THero hero) where THero : class, IHero
            //{
            //    hero = builder.WithNameEqualTo(value);

            //    return (hero is null) ? false : true;
            //}

            //#endregion
    }
}
