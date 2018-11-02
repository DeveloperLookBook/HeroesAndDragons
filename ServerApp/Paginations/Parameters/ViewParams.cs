﻿using ServerApp.Data.Requests;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations
{
    public class ViewParams : IViewParams
    {
        public int  MaxPageSize     { get;      }
        public int  MinPageSize     { get;      }
        public int  MaxPageNumber   { get; set; }
        public int  MinPageNumber   { get;      }
        public int  PageSize        { get; set; }
        public int  PageNumber      { get; set; }

        public bool HasPreviousPage { get;      }
        public bool HasNextPage     { get;      }

        private int ModelsCount     { get;      }


        public ViewParams(int modelsCount, int pageNumber, int maxPageSize, int minPageSize, int pageSize)
        {
            this.ModelsCount   = modelsCount;
            this.MaxPageSize   = maxPageSize;
            this.MinPageSize   = minPageSize;
            this.PageSize      = (pageSize > this.MaxPageSize  ) ? this.MaxPageSize   : (pageSize < this.MinPageSize  ) ? this.MinPageSize : pageSize;

            this.MaxPageNumber = this.CountMaxPageNumber(this.PageSize, modelsCount);
            this.MinPageNumber = 0;
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
            return (minPageNumber < pageNumber -1);
        }
        private bool CurrentPageHasNextPage    (int pageNumber, int maxPageNumber)
        {
            return (maxPageNumber > pageNumber + 1);
        }
        public int   Skip()
        {
            int skip = this.PageSize;

            if (this.PageSize * this.PageNumber >= this.ModelsCount) skip = 0;
            if (this.PageSize * this.PageNumber <= 0               ) skip = 0;

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