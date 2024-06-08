using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternetProvider.Models;

namespace InternetProvider.Pages.Tasks
{
    public class Task6Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task6Model(InternetProviderContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]//Позволяет получать значение из параметра запроса
        public decimal Amount { get; set; }//Поле для хранения введенной суммы
        public List<Deal> Deals { get; set; }

        public IActionResult OnGet()
        {
            string sql = @"
                SELECT * 
                FROM ""Deal"" AS D
                WHERE {0} < ANY (
                    SELECT P.""Сумма""::numeric
                    FROM ""Payment"" AS P
                )";

            sql = string.Format(sql, Amount);//Подставляем значение в запрос
            Deals = _context.Deals.FromSqlRaw(sql).ToList();

            return Page();
        }
    }
}
