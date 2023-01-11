﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners22.Data;
using CapenexisLearners22.Models;

namespace CapenexisLearners22.Pages.LevelFiveLearners
{
    public class DetailsModel : PageModel
    {
        private readonly CapenexisLearners22.Data.CapenexisLearners22Context _context;

        public DetailsModel(CapenexisLearners22.Data.CapenexisLearners22Context context)
        {
            _context = context;
        }

      public LevelFiveLearner LevelFiveLearner { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LevelFiveLearner == null)
            {
                return NotFound();
            }

            var levelfivelearner = await _context.LevelFiveLearner.FirstOrDefaultAsync(m => m.Id == id);
            if (levelfivelearner == null)
            {
                return NotFound();
            }
            else 
            {
                LevelFiveLearner = levelfivelearner;
            }
            return Page();
        }
    }
}