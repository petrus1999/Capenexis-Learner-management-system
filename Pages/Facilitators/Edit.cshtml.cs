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

namespace CapenexisLearners22.Pages.Facilitators
{
    public class EditModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public EditModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Facilitator Facilitator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator =  await _context.Facilitator.FirstOrDefaultAsync(m => m.Id == id);
            if (facilitator == null)
            {
                return NotFound();
            }
            Facilitator = facilitator;
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

            _context.Attach(Facilitator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitatorExists(Facilitator.Id))
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

        private bool FacilitatorExists(int id)
        {
          return (_context.Facilitator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
