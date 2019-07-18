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
        private readonly Uri url = new Uri("https://localhost:44340");

        public List<Category> GetAllCategories()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/categories/get").Result;

                string jsonString = response.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                return responseData;
            }
        }

        public List<Word> GetAllWords()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/words/get").Result;

                string jsonString = response.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<List<Word>>(jsonString);
                return responseData;
            }
        }
    }
}
