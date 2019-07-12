using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.DTOs
{
    public abstract class BaseDTO<T> // ID type can be of Int32 or Guid
    {
        public T ID { get; set; }
    }
}
