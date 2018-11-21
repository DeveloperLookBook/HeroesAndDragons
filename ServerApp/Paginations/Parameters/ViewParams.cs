using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations
{
    public class ViewParams : IViewParams
    {
        public int  MaxPageSize     { get; protected set; } = 100;
        public int  MinPageSize     { get; protected set; } = 1;
        public int  MaxPageNumber   { get; protected set; }
        public int  MinPageNumber   { get; protected set; } = 1;
        public int  PageSize        { get;           set; } = 1;
        public int  PageNumber      { get;           set; } = 1;
        public bool HasPreviousPage { get; protected set; } = false;
        public bool HasNextPage     { get; protected set; } = false;
        public int  ModelsCount     { get; protected set; } = 0;


        public ViewParams(int modelsCount, int pageNumber, int maxPageSize, int minPageSize, int pageSize)
        {
            this.ModelsCount   = modelsCount;
            this.MaxPageSize   = maxPageSize;
            this.MinPageSize   = minPageSize;
            this.PageSize      = (pageSize > this.MaxPageSize  ) ? this.MaxPageSize   : (pageSize < this.MinPageSize  ) ? this.MinPageSize : pageSize;

            this.MaxPageNumber = this.CountMaxPageNumber(this.PageSize, modelsCount);
            this.MinPageNumber = 1;
            this.PageNumber    = this.GetValidatedPageNumber(pageNumber, this.MinPageNumber, this.MaxPageNumber);

            this.HasPreviousPage = this.CurrentPageHasPreviousPage(pageNumber, this.MinPageNumber);
            this.HasNextPage     = this.CurrentPageHasNextPage    (pageNumber, this.MaxPageNumber);
        }


        private int  CountMaxPageNumber        (int pageSize  , int modelsCount)
        {
            var maxPageNumber = 0;

            if (pageSize > 0 && modelsCount > 0) maxPageNumber = (int)Math.Ceiling(modelsCount / (double)pageSize);

            return maxPageNumber;
        }
        private int  GetValidatedPageNumber    (int pageNumber, int minPageNumber, int maxPageNumber)
        {
            return (pageNumber > maxPageNumber) ? maxPageNumber : (pageNumber < minPageNumber) ? minPageNumber : pageNumber;
        }
        private bool CurrentPageHasPreviousPage(int pageNumber, int minPageNumber)
        {
            return (minPageNumber < pageNumber);
        }
        private bool CurrentPageHasNextPage    (int pageNumber, int maxPageNumber)
        {
            return (maxPageNumber > pageNumber);
        }
        public  int  Skip()
        {
            int skip = ((this.PageNumber * this.PageSize) - this.PageSize);

            if (skip >  this.ModelsCount) skip = 0;
            if (skip <= 0               ) skip = 0;

            return skip;
        }


        #region PROTOTYPE PATTERN

        protected ViewParams(ViewParams @params)
        {
            if (@params is null) throw new ArgumentNullException(nameof(@params));

            MaxPageSize     = @params.MaxPageSize;
            MinPageSize     = @params.MinPageSize;
            MaxPageNumber   = @params.MaxPageNumber;
            MinPageNumber   = @params.MinPageNumber;
            PageSize        = @params.PageSize;
            PageNumber      = @params.PageNumber;


            HasPreviousPage = @params.HasPreviousPage;
            HasNextPage     = @params.HasNextPage;


            ModelsCount     = @params.ModelsCount;
        }

        public IViewParams Clone()
        {
            return new ViewParams(this);
        }

        #endregion
    }
}
