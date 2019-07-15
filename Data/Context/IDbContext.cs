using HM.Data.Abstraction;
using HM.Data.Entities.GameItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Data.Context
{
    public interface IDbContext<T>
        where T:BaseEntity<int>
    {
        
    }
}
