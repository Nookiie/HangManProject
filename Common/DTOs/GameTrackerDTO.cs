using Data.Entities;
using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.DTOs
{
    public class GameTrackerDTO : BaseDTO<int>
    {
        public string Name { get; set; }
    }
}
