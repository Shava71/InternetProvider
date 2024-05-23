using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InternetProvider;

namespace InternetProvider.Pages.ClientTable
{
    public class CreateModel : PageModel
    {
        private readonly InternetProvider.InternetProviderContext _context;

        public CreateModel(InternetProvider.InternetProviderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["НомерДоговора"] = new SelectList(_context.Deals, "НомерДоговора", "НомерДоговора");
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
