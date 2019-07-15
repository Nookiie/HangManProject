using HangmanLogic.Logic;
using HM.Data.Entities.GameItems;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Components
{
    public class GameManager : ComponentBase
    {
        [Inject]
        public GameLogic GameLogic;

        public Category Category { get; set; }
    }
}
