using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Data.Abstraction
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {

        }

        public int ID { get; set; }
    }
}
