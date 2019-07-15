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
    public class DetailsModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;

        public DetailsModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        public Category GameTracker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameTracker = await _context.Categories.FirstOrDefaultAsync(m => m.ID == id);

            if (GameTracker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
