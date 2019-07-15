using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HM.Data.Abstraction;
using HM.Data.Entities;

namespace HM.Data.Entities.GameItems
{
    /// <summary>
    /// The Main Game Manager that coordinates and manages the wordlist
    /// </summary>
    public class Category : BaseEntity<int>
    {
        #region Constructor

        public Category()
        {

        }

        public Category(string category)
        {
            this.Name = category;
        }

        #endregion

        #region Properties

        [Required]
        [MinLength(3, ErrorMessage = "Category Name is too short")]
        [MaxLength(40, ErrorMessage = "Category Name is too long")]
        public string Name { get; set; }

        #endregion

    }
}
