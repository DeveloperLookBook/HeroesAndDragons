﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Services.Helpers
{
    public enum HitsOrdering
    {
        ByTargetName,
        BySourceName,
        ByWeaponName,
        ByWeaponStrength,
        ByStrength,
        ByCreated,
    }
}
