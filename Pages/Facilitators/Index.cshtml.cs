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

namespace CapenexisLearners22.Pages.Facilitators
{
    public class IndexModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public IndexModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

        public IList<Facilitator> Facilitator { get; set; } = default!;


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FacilitatorName { get; set; }

            public async Task OnGetAsync()
            {
                var facilitators = from m in _context.Facilitator
                             select m;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    facilitators = facilitators.Where(s => s.FirstName.Contains(SearchString));
                }

                Facilitator = await facilitators.ToListAsync();
            }
        }
    }
