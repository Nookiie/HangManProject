using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HM.Blazor.Pages.Words
{
    public class IndexModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;
        private readonly Uri url = new Uri("https://localhost:44340/api/words/");

        public IndexModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        public IList<Word> Words { get;set; }

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
