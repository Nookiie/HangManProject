using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HM.Data.Context;
using HM.Data.Entities.GameItems;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HM.Blazor.Pages.Words
{
    public class CreateModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;
        private readonly Uri url = new Uri("https://localhost:44340/api/words/get");

        public CreateModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Word Word { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync(Word word)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(word == null)
            {
                return NotFound();
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Add the Authorization header with the AccessToken.
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var content = JsonConvert.SerializeObject(word);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // make the request
                HttpResponseMessage response = await client.PostAsync("create", byteContent);

                // parse the response and return the data.
                //string jsonString = await response.Content.ReadAsStringAsync();
                //var responseData = JsonConvert.DeserializeObject<GenreVM>(jsonString);
                //return View(responseData);
            }

            return RedirectToAction("Index");
        }
    }
}