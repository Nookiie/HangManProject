using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;

namespace HM.Blazor.Pages.GameTrackers
{
    public class IndexModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;

        public IndexModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        public IList<GameTracker> GameTracker { get;set; }

        public async Task OnGetAsync()
        {
            GameTracker = await _context.GameTrackers.ToListAsync();
        }
    }
}
