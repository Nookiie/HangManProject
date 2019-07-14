﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly HM.Data.Context.HangmanDbContext _context;

        public DeleteModel(HM.Data.Context.HangmanDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameTracker = await _context.GameTrackers.FindAsync(id);

            if (GameTracker != null)
            {
                _context.GameTrackers.Remove(GameTracker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}