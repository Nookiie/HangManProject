using HM.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Data.Entities.GameItems
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
