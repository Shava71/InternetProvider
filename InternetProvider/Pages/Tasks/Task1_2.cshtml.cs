using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetProvider.Pages.Tasks
{
    public class Task1_2Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task1_2Model(InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TariffNumber { get; set; }

        public IList<Deal> Deals { get; set; }

        public async Task<IActionResult> OnGetShowDealsAsync()
        {
            if (StartDate == default || EndDate == default || TariffNumber == default)
            {
                Deals = new List<Deal>();
                return Page(); // Возврат страницы без выполнения запроса, если параметры не были переданы
            }

            // Выполнение SQL-запроса напрямую с именованными параметрами
            var query = @"
                SELECT * 
                FROM Deals
                WHERE ДатаЗаключения >= @StartDate AND ДатаЗаключения <= @EndDate AND НомерТарифа = @TariffNumber";

            Deals = await _context.Deals
                .FromSqlRaw(query,
                            new SqlParameter("@StartDate", StartDate),
                            new SqlParameter("@EndDate", EndDate),
                            new SqlParameter("@TariffNumber", TariffNumber))
                .ToListAsync();

            return Page();
        }
    }
}
