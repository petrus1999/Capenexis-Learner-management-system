using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners22.Data;
using CapenexisLearners22.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapenexisLearners22.Pages.Learners
{
    public class IndexModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public IndexModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

        public IList<Learner> Learner { get;set; } = default!;



        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Course { get; set; }
        

        [BindProperty(SupportsGet = true)]
        public string? LearnerName { get; set; }

      

        

        

       

        public async Task OnGetAsync()
        {
            var learners = from m in _context.Learner
                               select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                learners = learners.Where(predicate: s => s.Course.Contains(SearchString));
            }

            Learner= await learners.ToListAsync();


           
        }
    
    }
}
