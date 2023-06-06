using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pigmalion.Models;

namespace Pigmalion.Controllers
{
    public class ClientsController : Controller
    {
        private readonly PigmalionContext _context;

        public ClientsController(PigmalionContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var pigmalionContext = _context.Clients
                .Include(c => c.IdcityclientNavigation)
                .Include(c => c.IdcountryclientNavigation)
                .Include(c => c.IddirectionclientNavigation).
                Include(c => c.IdregionclientNavigation);
            return View(await pigmalionContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdcityclientNavigation)
                .Include(c => c.IdcountryclientNavigation)
                .Include(c => c.IddirectionclientNavigation)
                .Include(c => c.IdregionclientNavigation)
                .FirstOrDefaultAsync(m => m.IdClient == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["NameCountry"] = new SelectList(_context.Countries, "IdCountry", "NameCountry");
            ViewData["NameCity"] = new SelectList(_context.Cities, "IdCity", "NameCity");
            ViewData["NameRegion"] = new SelectList(_context.Regions, "IdRegion", "NameRegion");
            ViewData["NameDirection"] = new SelectList(_context.Directions, "IdDirection", "NameDirection");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClient,Phonenum,DateCreation,Appeal,Idcountryclient,Idregionclient,Idcityclient,Iddirectionclient")] Client client)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcityclient"] = new SelectList(_context.Cities, "IdCity", "IdCity", client.Idcityclient);
            ViewData["Idcountryclient"] = new SelectList(_context.Countries, "IdCountry", "IdCountry", client.Idcountryclient);
            ViewData["Iddirectionclient"] = new SelectList(_context.Directions, "IdDirection", "IdDirection", client.Iddirectionclient);
            ViewData["Idregionclient"] = new SelectList(_context.Regions, "IdRegion", "IdRegion", client.Idregionclient);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["Idcityclient"] = new SelectList(_context.Cities, "IdCity", "NameCity", client.Idcityclient);
            ViewData["Idcountryclient"] = new SelectList(_context.Countries, "IdCountry", "NameCountry", client.Idcountryclient);
            ViewData["Iddirectionclient"] = new SelectList(_context.Directions, "IdDirection", "NameDirection", client.Iddirectionclient);
            ViewData["Idregionclient"] = new SelectList(_context.Regions, "IdRegion", "NameRegion", client.Idregionclient);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClient,Phonenum,DateCreation,Appeal,Idcountryclient,Idregionclient,Idcityclient,Iddirectionclient")] Client client)
        {
            if (id != client.IdClient)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.IdClient))
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
            ViewData["Idcityclient"] = new SelectList(_context.Cities, "IdCity", "NameCity", client.Idcityclient);
            ViewData["Idcountryclient"] = new SelectList(_context.Countries, "IdCountry", "NameCountry", client.Idcountryclient);
            ViewData["Iddirectionclient"] = new SelectList(_context.Directions, "IdDirection", "NameDirection", client.Iddirectionclient);
            ViewData["Idregionclient"] = new SelectList(_context.Regions, "IdRegion", "NameRegion", client.Idregionclient);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdcityclientNavigation)
                .Include(c => c.IdcountryclientNavigation)
                .Include(c => c.IddirectionclientNavigation)
                .Include(c => c.IdregionclientNavigation)
                .FirstOrDefaultAsync(m => m.IdClient == id);
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
            if (_context.Clients == null)
            {
                return Problem("Entity set 'PigmalionContext.Clients'  is null.");
            }
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
          return (_context.Clients?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }
    }
}
