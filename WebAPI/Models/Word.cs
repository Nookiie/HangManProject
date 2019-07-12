using HM.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class Word : BaseEntity<int>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Word is too short")]
        [MaxLength(20, ErrorMessage = "Word is too long")]
        public string Name { get; set; }
    }
}
