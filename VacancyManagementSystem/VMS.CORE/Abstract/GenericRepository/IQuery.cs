﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.CORE.Abstract.GenericRepository
{
    public interface IQuery<TEntity>
    {
        IQueryable<TEntity> Query();
    }
}
