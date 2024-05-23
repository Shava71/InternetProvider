using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Pages.Tasks
{
    public class TariffUsage
    {
        public int TariffNumber { get; set; }
        public Dictionary<string, int> MonthlyUsage { get; set; }
    }

    public class Task2Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task2Model(InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public DateOnly StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly EndDate { get; set; }

        public IList<TariffUsage> TariffUsages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (StartDate == default || EndDate == default)
            {
                return Page();
            }

            TariffUsages = new List<TariffUsage>();

            for (int tariffNumber = 1; tariffNumber <= 5; tariffNumber++)
            {
                var monthlyUsage = await _context.Deals
                    .Where(d => d.ДатаЗаключения >= StartDate && d.ДатаЗаключения <= EndDate && d.НомерТарифа == tariffNumber)
                    .GroupBy(d => new { Year = d.ДатаЗаключения.Year, Month = d.ДатаЗаключения.Month })
                    .Select(g => new { MonthYear = $"{g.Key.Year}-{g.Key.Month}", Count = g.Count() })
                    .ToDictionaryAsync(x => x.MonthYear, x => x.Count);
                    
                TariffUsages.Add(new TariffUsage { TariffNumber = tariffNumber, MonthlyUsage = monthlyUsage });
            }

            return Page();
        }
    }
}
