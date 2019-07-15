using Data.Entities.Users;
using HM.Data.Entities.GameItems;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Components
{
    public class LoginManager : ComponentBase
    {
        private readonly Uri url = new Uri("https://localhost:44340/api/users/");

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public void MapToSession(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }

        public async Task LogUser(object id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get/" + id);

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<User>(jsonString);
                User user = responseData;

                MapToSession(user);
            }
        }
    }
}
