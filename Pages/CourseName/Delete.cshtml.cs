using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners22.Data;
using CapenexisLearners22.Models;

namespace CapenexisLearners22.Pages.CourseName
{
    public class DeleteModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public DeleteModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Courses Courses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var courses = await _context.Course.FirstOrDefaultAsync(m => m.Id == id);

            if (courses == null)
            {
                return NotFound();
            }
            else 
            {
                Courses = courses;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }
            var courses = await _context.Course.FindAsync(id);

            if (courses != null)
            {
                Courses = courses;
                _context.Course.Remove(Courses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
