using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Pages.Tasks
{
    public class Task3Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task3Model(InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public DateOnly StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly EndDate { get; set; }

        public List<Payment> Payments { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (StartDate == default || EndDate == default)
            {
                Payments = new List<Payment>();
            }
            else
            {
                Payments = await _context.Payments
                    .Where(p => p.Дата >= StartDate && p.Дата <= EndDate)
                    .OrderBy(p => p.Дата)
                    .ToListAsync();
            }

            return Page();
        }
    }
}
