using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Word : BaseEntity
    {
        public Word()
        {

        }

        public Word(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
