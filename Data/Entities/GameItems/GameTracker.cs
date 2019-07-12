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
    public class GameTracker : BaseEntity<int>
    {
        #region Constructor

        public GameTracker()
        {

        }

        public GameTracker(string category, List<Word> words)
        {
            this.Words = words;
            this.Category = category;
        }

        #endregion

        #region Properties

        [Required]
        [MinLength(3, ErrorMessage = "Category is too short")]
        [MaxLength(40, ErrorMessage = "Category is too long")]
        public string Category { get; set; }

        public List<Word> Words { get; set; }

        #endregion

    }
}
