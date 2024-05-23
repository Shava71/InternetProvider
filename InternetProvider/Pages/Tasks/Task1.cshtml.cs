using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Pages.Tasks
{
    public class Task1Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task1Model(InternetProviderContext context)
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

        public async Task<IActionResult> OnGetAsync()
        {
            if (StartDate == default || EndDate == default || TariffNumber == default)
            {
                return Page(); 
            }

            //�������������� DateTime � DateOnly
            var startDate = new DateOnly(StartDate.Year, StartDate.Month, StartDate.Day);
            var endDate = new DateOnly(EndDate.Year, EndDate.Month, EndDate.Day);

            //������ � ���� ������ � �������������� ���������� StartDate, EndDate � TariffNumber
            Deals = await _context.Deals
                .Where(d => d.�������������� >= startDate && d.�������������� <= endDate && d.����������� == TariffNumber)
                .ToListAsync();

            return Page();
        }
    }
}
