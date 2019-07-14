using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HM.Blazor.Pages.Words
{
    public class EditModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;
        private readonly Uri url = new Uri("https://localhost:44340/api/words/");

        public EditModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Word Words { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Add the Authorization header with the AccessToken.
                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                // make the request
                HttpResponseMessage response = await client.GetAsync("get/" + id);

                // parse the response and return the data.
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Word>(jsonString);
                Words = responseData;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(Word word)
        {
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
                HttpResponseMessage response = await client.PostAsync("update", byteContent);

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Word>(jsonString);
                Words = responseData;
                return RedirectToAction("./index");
            }
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.ID == id);
        }
    }
}
