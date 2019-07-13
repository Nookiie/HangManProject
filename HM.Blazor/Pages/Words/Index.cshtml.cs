using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;

namespace HM.Blazor.Pages.Words
{
    public class IndexModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;

        public IndexModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        public IList<Word> Word { get;set; }

        public async Task OnGetAsync()
        {
            Word = await _context.Words.ToListAsync();
        }
    }
}
