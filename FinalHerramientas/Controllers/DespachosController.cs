using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalHerramientas.Data;
using FinalHerramientas.Models;

namespace FinalHerramientas.Controllers
{
    public class DespachosController : Controller
    {
        private readonly VinotecaDbContext _context;

        public DespachosController(VinotecaDbContext context)
        {
            _context = context;
        }

        // GET: Despacho
        public async Task<IActionResult> Index()
        {
            var vinotecaDbContext = _context.Despachos.Include(d => d.Nombre);
            return View(await vinotecaDbContext.ToListAsync());
        }

        // GET: Despacho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos
                .Include(d => d.Nombre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // GET: Despacho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Despacho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteID,Fecha,Estado,Total")] Despacho despacho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despacho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despacho);
        }

        // GET: Despacho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho == null)
            {
                return NotFound();
            }
            return View(despacho);
        }

        // POST: Despacho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteID,Fecha,Estado,Total")] Despacho despacho)
        {
            if (id != despacho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despacho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespachoExists(despacho.Id))
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
            return View(despacho);
        }

        // GET: Despacho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos
                .Include(d => d.Nombre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // POST: Despacho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho != null)
            {
                _context.Despachos.Remove(despacho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespachoExists(int id)
        {
            return _context.Despachos.Any(e => e.Id == id);
        }
    }
}
