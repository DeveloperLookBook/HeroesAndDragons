using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Paginations.OrderingStrategies
{
    public enum DragonsOrderingStrategy
    {
        OrderByNameAsc,
        OrderByNameDes,
        OrderByHealthAsc,
        OrderByHealthDes,
        OrderByCreationTimeAsc,
        OrderByCreationTimeDes,
    }
}
