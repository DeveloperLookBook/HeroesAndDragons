using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.Parameters
{
    public class DefaultViewModelParams : ViewModelParams
    {
        public DefaultViewModelParams() : base(100, 1, 1, 10)
        {
        }
    }
}
