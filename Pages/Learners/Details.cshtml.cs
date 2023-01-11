using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners22.Data;
using CapenexisLearners22.Models;

namespace CapenexisLearners22.Pages.Learners
{
    public class DetailsModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public DetailsModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

      public Learner Learner { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Learner == null)
            {
                return NotFound();
            }

            var learner = await _context.Learner.FirstOrDefaultAsync(m => m.Id == id);
            if (learner == null)
            {
                return NotFound();
            }
            else 
            {
                Learner = learner;
            }
            return Page();
        }
    }
}
