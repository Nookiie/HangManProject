using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.DTOs
{
    public class WordDTO : BaseDTO<int>
    {
        public string Name { get; set; }
    }
}
