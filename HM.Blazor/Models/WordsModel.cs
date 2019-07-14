using HM.Data.Entities.GameItems;
using HM.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HM.Blazor.Models
{
    public class WordsModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;
        private readonly IUnitOfWork unitOfWork;
        private readonly Uri url = new Uri("https://localhost:44340/api/words/");

        public WordsModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        public IList<Word> Words { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Add the Authorization header with the AccessToken.
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                // make the request
                HttpResponseMessage response = await client.GetAsync("get");

                // parse the response and return the data.
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<Word>>(jsonString);
                Words = responseData;
                return Page();
            }
        }
    }
}
