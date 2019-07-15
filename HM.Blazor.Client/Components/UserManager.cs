using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HM.Blazor.Client.Components
{
    public class UserManager : ComponentBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public async Task RegisterUser()
        {

        }
    }
}
