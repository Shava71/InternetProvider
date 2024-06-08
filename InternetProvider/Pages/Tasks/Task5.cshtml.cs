using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using InternetProvider.Models;

namespace InternetProvider.Pages.Tasks
{
    public class Task5Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task5Model(InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TariffSelectionViewModel TariffSelection { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var tariffs = await _context.GetTariffsAsync();
            TariffSelection = new TariffSelectionViewModel
            {
                Tariffs = tariffs,
                SelectedTariffId = tariffs.Count > 0 ? tariffs[0].НомерТарифа : 0
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var totalClients = await _context.GetTotalClientsByTariffAsync(TariffSelection.SelectedTariffId);
            var tariffs = await _context.GetTariffsAsync();

            TariffSelection.Tariffs = tariffs;
            TariffSelection.TotalClients = totalClients;

            return Page();
        }
    }
}
