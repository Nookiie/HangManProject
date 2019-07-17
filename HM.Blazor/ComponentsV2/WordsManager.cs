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

namespace ComponentsV2
{
    public class WordsManager : ComponentBase
    {
        private readonly Uri url = new Uri("https://localhost:44340/api");

        public async Task<List<Category>> GetAllCategories()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("categories/get");

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                return responseData;
            }
        }

        public async Task<List<Word>> GetAllWords()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("words/get");

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<Word>>(jsonString);
                return responseData;
            }
        }
    }
}
