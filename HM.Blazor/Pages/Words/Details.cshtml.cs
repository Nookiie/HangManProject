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
    public class DetailsModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;
        private readonly Uri url = new Uri("https://localhost:44340/api/words/");

        public DetailsModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Word Word { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync("get/" + id);

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Word>(jsonString);
                Word = responseData;

                if (Word.GetType() != typeof(Word))
                {
                    return NotFound();
                }

                return Page();
            }
        }
    }
}


