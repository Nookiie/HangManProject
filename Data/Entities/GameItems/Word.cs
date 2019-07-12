using HM.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HM.Data.Entities.GameItems
{
    public class Word : BaseEntity<int>
    {
        public Word()
        {

        }

        public Word(string name)
        {
            this.Name = name;
        }

        [Required]
        [MinLength(3, ErrorMessage = "Word is too short")]
        [MaxLength(20, ErrorMessage = "Word is too long")]
        public string Name { get; set; }
    }
}
