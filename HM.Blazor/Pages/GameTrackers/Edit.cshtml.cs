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

namespace HM.Blazor.Pages.GameTrackers
{
    public class EditModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;

        public EditModel(HM.Data.Context.HangmanDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameTracker GameTracker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameTracker = await _context.GameTrackers.FirstOrDefaultAsync(m => m.ID == id);

            if (GameTracker == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GameTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameTrackerExists(GameTracker.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameTrackerExists(int id)
        {
            return _context.GameTrackers.Any(e => e.ID == id);
        }
    }
}
