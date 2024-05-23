using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Pages.Tasks
{
    public class Task4Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task4Model(InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        public Dictionary<int, decimal> TariffSums { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (StartDate == default || EndDate == default)
            {
                return Page(); 
            }
 
            var startDate = new DateOnly(StartDate.Year, StartDate.Month, StartDate.Day);
            var endDate = new DateOnly(EndDate.Year, EndDate.Month, EndDate.Day);

            //Запрос к базе данных для суммирования платежей по тарифам за указанный период
            TariffSums = await _context.Payments
                .Where(p => p.Дата >= startDate && p.Дата <= endDate)
                .Include(p => p.НомерДоговораNavigation)
                .GroupBy(p => p.НомерДоговораNavigation.НомерТарифа)
                .Select(g => new { TariffNumber = g.Key, TotalSum = g.Sum(p => p.Сумма) })
                .ToDictionaryAsync(x => x.TariffNumber, x => x.TotalSum);

            return Page();
        }
    }
}
