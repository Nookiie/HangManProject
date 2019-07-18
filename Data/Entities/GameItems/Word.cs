using HM.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Word(string name, Category category)
        {
            this.Name = name;
            this.Category = category;
        }

        [Required]
        [MinLength(3, ErrorMessage = "Word Name is too short")]
        [MaxLength(20, ErrorMessage = "Word Name is too long")]
        public string Name { get; set; }
        
        public Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
    }
}
