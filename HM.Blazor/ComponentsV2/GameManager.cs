using HangmanLogic.Logic;
using HM.Data.Entities.GameItems;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentsV2
{
    public class GameManager : ComponentBase
    {
        public Category Category { get; set; }
    }
}
