using Data.Entities.Users;
using HM.Blazor.Session;
using HM.Data.Entities.GameItems;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ComponentsV2
{
    public class LoginManager : ComponentBase
    {
        private readonly Uri url = new Uri("https://localhost:44340/api/users/");

        SessionManager session = new SessionManager();

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public void LogUser()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("getbyusername/" + Username).Result;

                string jsonString = response.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<User>(jsonString);

                if (responseData.GetType() != typeof(User))
                {
                    return;
                }

                User user = responseData;
                session.MapToSession(user);

            }
        }
    }
}
