using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Components
{
    public class BaseManager
    {
        private Uri Url { get; } = new Uri("https://localhost:44340/api/words/");
    }
}
