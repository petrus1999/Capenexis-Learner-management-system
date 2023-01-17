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
    public class IndexModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public IndexModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

        public IList<Courses> Courses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Course != null)
            {
                Courses = await _context.Course.ToListAsync();
            }
        }
    }
}
