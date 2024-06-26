using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Vidhyalaya.Pages_Guardians
{
    public class DetailsModel : PageModel
    {
        private readonly VidhyalayaDbContext _context;

        public DetailsModel(VidhyalayaDbContext context)
        {
            _context = context;
        }

        public Guardian Guardian { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var guardian = await _context.Guardians.FirstOrDefaultAsync(m => m.Id == id);
            var guardian = await _context.Guardians
              .Include(g => g.Student) // Include Student navigation property
              .FirstOrDefaultAsync(m => m.Id == id);
            if (guardian == null)
            {
                return NotFound();
            }
            else
            {
                Guardian = guardian;
            }
            return Page();
        }
    }
}
