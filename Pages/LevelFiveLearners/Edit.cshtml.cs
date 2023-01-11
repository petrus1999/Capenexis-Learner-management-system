using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners22.Data;
using CapenexisLearners22.Models;

namespace CapenexisLearners22.Pages.LevelFiveLearners
{
    public class EditModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public EditModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

        [BindProperty]
        public LevelFiveLearner LevelFiveLearner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LevelFiveLearner == null)
            {
                return NotFound();
            }

            var levelfivelearner =  await _context.LevelFiveLearner.FirstOrDefaultAsync(m => m.Id == id);
            if (levelfivelearner == null)
            {
                return NotFound();
            }
            LevelFiveLearner = levelfivelearner;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LevelFiveLearner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelFiveLearnerExists(LevelFiveLearner.Id))
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

        private bool LevelFiveLearnerExists(int id)
        {
          return (_context.LevelFiveLearner?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
