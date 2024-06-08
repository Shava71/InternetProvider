using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InternetProvider.Models;
using System.Collections.Generic;
using System.Linq;

namespace InternetProvider.Pages.Tasks
{
    public class Task7Model : PageModel
    {
        private readonly InternetProviderContext _context;

        public Task7Model(InternetProviderContext context)
        {
            _context = context;
        }

        public List<ClientViewTechno> ClientviewTechnos { get; set; }

        public IActionResult OnGet()
        {
            string sql = @"
        DROP VIEW IF EXISTS clientView_Techno;
        CREATE VIEW clientView_Techno
        AS 
        SELECT 
            ""Client"".""Номер клиента"", 
            ""Client"".""Фамилия"", 
            ""Client"".""Имя"", 
            ""Client"".""Отчество"",
            ""Client"".""Адрес"", 
            ""Client"".""Номер телефона"", 
            ""Client"".""Электронная почта"", 
            ""Client"".""Дата рождения"", 
            ""Deal"".""Номер договора"", 
            ""Deal"".""Номер тарифа""
        FROM ""Client""
        JOIN ""Deal"" ON ""Deal"".""Номер договора"" = ""Client"".""Номер договора"";
        
        SELECT * FROM clientView_Techno;
    ";

            ClientviewTechnos = _context.ClientviewTechnos.FromSqlRaw(sql).ToList();

            return Page();
        }
    }
}
