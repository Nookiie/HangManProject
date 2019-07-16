﻿using Data.Entities.Users;
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

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public User User { get; set; } = new User();

        public void MapUser(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }

        public async void SaveDataForm()
        {
            Username = User.Username;
            Password = User.Password;
            Email = User.Email;

            await RegisterUser();
        }

        public async Task RegisterUser()
        {
            using (var client = new HttpClient())
            {   
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Add the Authorization header with the AccessToken.
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync("create");

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<User>(jsonString);

                MapUser(User);
            }
        }
    }
}
