using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HM.Data.Abstraction
{
    public abstract class BaseEntity<T>
    {
        public BaseEntity()
        {

        }

        [Key]
        public T ID { get; set; }
    }
}
