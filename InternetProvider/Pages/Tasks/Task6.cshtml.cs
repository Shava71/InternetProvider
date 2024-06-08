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
        [BindProperty(SupportsGet = true)]//��������� �������� �������� �� ��������� �������
        public decimal Amount { get; set; }//���� ��� �������� ��������� �����
        public List<Deal> Deals { get; set; }

        public IActionResult OnGet()
        {
            string sql = @"
                SELECT * 
                FROM ""Deal"" AS D
                WHERE {0} < ANY (
                    SELECT P.""�����""::numeric
                    FROM ""Payment"" AS P
                )";

            sql = string.Format(sql, Amount);//����������� �������� � ������
            Deals = _context.Deals.FromSqlRaw(sql).ToList();

            return Page();
        }
    }
}
