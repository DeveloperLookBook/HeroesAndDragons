using ServerApp.Data.Requests;
using ServerApp.Models;
using ServerApp.Paginations.OrderingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations
{
    public abstract class ViewModelParams : IViewModelParams
    {
        private int pageSize;

        public int MaxPageSize { get;      }
        public int MinPageSize { get;      }
        public int PageNumber  { get; set; }

        public int PageSize
        {
            get => this.pageSize;
            set => this.pageSize = (value > MaxPageSize) ? this.MaxPageSize : (value < MinPageSize) ? this.MinPageSize : value;            
        }


        public ViewModelParams(int maxPageSize, int minPageSize, int pageNumber, int pageSize)
        {
            this.MaxPageSize = maxPageSize;
            this.MinPageSize = minPageSize;
            this.PageNumber  = pageNumber ;
            this.PageSize    = pageSize   ;
        }
    }
}
