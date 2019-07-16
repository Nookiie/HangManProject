using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HM.Blazor.Components.API_Service
{
    public static class APIConnector
    {
        public static Uri Url { get; } = new Uri("https://localhost:44340/api/");
    }
}
