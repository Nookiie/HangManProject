using HM.Data.Abstraction;
using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class GameTracker : BaseEntity<int>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Category is too short")]
        [MaxLength(40, ErrorMessage = "Category is too long")]
        public string Category { get; set; }

        public List<Word> Words { get; set; }
    }
}
