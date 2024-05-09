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
        private readonly VidhyalaDbContext _context;

        public DetailsModel(VidhyalaDbContext context)
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

            var guardian = await _context.Guardian.FirstOrDefaultAsync(m => m.Id == id);
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
