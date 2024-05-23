using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetProvider;

namespace InternetProvider.Pages.ClientTable
{
    public class ClientsController : Controller
    {
        private readonly InternetProviderContext _context;

        public ClientsController(InternetProviderContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var internetProviderContext = _context.Clients.Include(c => c.НомерДоговораNavigation);
            return View(await internetProviderContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.НомерДоговораNavigation)
                .FirstOrDefaultAsync(m => m.НомерКлиента == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["НомерДоговора"] = new SelectList(_context.Deals, "НомерДоговора", "НомерДоговора");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("НомерКлиента,Фамилия,Имя,Отчество,Адрес,НомерТелефона,ЭлектроннаяПочта,ДатаРождения,НомерДоговора")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["НомерДоговора"] = new SelectList(_context.Deals, "НомерДоговора", "НомерДоговора", client.НомерДоговора);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["НомерДоговора"] = new SelectList(_context.Deals, "НомерДоговора", "НомерДоговора", client.НомерДоговора);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("НомерКлиента,Фамилия,Имя,Отчество,Адрес,НомерТелефона,ЭлектроннаяПочта,ДатаРождения,НомерДоговора")] Client client)
        {
            if (id != client.НомерКлиента)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.НомерКлиента))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["НомерДоговора"] = new SelectList(_context.Deals, "НомерДоговора", "НомерДоговора", client.НомерДоговора);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.НомерДоговораNavigation)
                .FirstOrDefaultAsync(m => m.НомерКлиента == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.НомерКлиента == id);
        }
    }
}
