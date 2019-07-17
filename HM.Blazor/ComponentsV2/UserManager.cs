using Data.Entities.Users;
using HM.Blazor.Session;
using HM.Data.Entities.GameItems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComponentsV2
{
    public class UserManager : ComponentBase
    {
        private readonly Uri url = new Uri("https://localhost:44340/api/users/");

        SessionManager session = new SessionManager();

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public async Task RegisterUser()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("create");

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<User>(jsonString);
                User user = responseData;

                if (user == null)
                {
                    return;
                }
                else
                {
                    session.MapToSession(user);
                }
            }
        }
    }
}
