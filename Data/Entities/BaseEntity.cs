using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }

        public BaseEntity(string name)
        {
            this.Name = name;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual string GetName()
        {
            return this.Name;
        }
    }
}
