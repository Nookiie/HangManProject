using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.DTOs
{
    public class GameTrackerDTO : BaseDTO
    {
        public string Category { get; set; }

        public List<Word> Words { get; set; }

    }
}
