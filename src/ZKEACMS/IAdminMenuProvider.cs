﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZKEACMS.Common.Models;

namespace ZKEACMS
{
    public interface IAdminMenuProvider
    {
        IEnumerable<AdminMenu> GetAdminMenus();
    }
}
