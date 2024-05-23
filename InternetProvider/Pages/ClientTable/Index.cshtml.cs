using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternetProvider;

namespace InternetProvider.Pages.ClientTable
{
    public class IndexModel : PageModel
    {
        private readonly InternetProvider.InternetProviderContext _context;

        public IndexModel(InternetProvider.InternetProviderContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Clients
                .Include(c => c.НомерДоговораNavigation).ToListAsync();
        }
    }
}
