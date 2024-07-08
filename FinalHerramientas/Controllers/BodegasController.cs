using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalHerramientas.Data;
using FinalHerramientas.Models;
using FinalHerramientas.Services;
using FinalHerramientas.ViewModels;

namespace FinalHerramientas.Controllers
{
    public class BodegasController : Controller
    {
        private readonly IBodegaService _bodegaService;

        public BodegasController(IBodegaService bodegaService)
        {
            _bodegaService = bodegaService;
        }

        // GET: Bodegas
        public async Task<IActionResult> Index(string filter)
        {
            var bodegasVM = new BodegaListVM();
            var bodegaList = await _bodegaService.GetAll(filter);
            foreach (var bodega in bodegaList)
            {
                bodegasVM.Bodegas.Add(new BodegaVM
                {
                    Id = bodega.Id,
                    Nombre = bodega.Nombre,
                    Pais = bodega.Pais,
                    Region = bodega.Region,
                });
            }

            return View(bodegasVM);
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _bodegaService.GetById(id);
            if (bodega == null)
            {
                return NotFound();
            }

            var vinos = bodega.Vinos ?? new List<Vino> { };

            ViewData["VinosBodega"] = new SelectList(vinos, "Id", "Nombre");
            var bodegaVM = new BodegaVM
            {
                Id = bodega.Id,
                Nombre = bodega.Nombre,
                Pais = bodega.Pais,
                Region = bodega.Region,
            };
            return View(bodegaVM);
        }

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,Region")] BodegaVM bodegaVM)
        {
            if (ModelState.IsValid)
            {
                var bodega = new Bodega
                {
                    Id = bodegaVM.Id,
                    Nombre = bodegaVM.Nombre,
                    Pais = bodegaVM.Pais,
                    Region = bodegaVM.Region,
                };
                await _bodegaService.Create(bodega);
                return RedirectToAction(nameof(Index));
            }
            return View(bodegaVM);
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _bodegaService.GetById(id);
            if (bodega == null)
            {
                return NotFound();
            }

            var bodegaVM = new BodegaVM
            {
                Id = bodega.Id,
                Nombre = bodega.Nombre,
                Pais = bodega.Pais,
                Region = bodega.Region,
            };

            return View(bodegaVM);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais,Region")] BodegaVM bodegaVM)
        {
            if (id != bodegaVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var bodega = await _bodegaService.GetById(bodegaVM.Id);
                if (bodega == null) { return NotFound(); }

                bodega.Nombre = bodegaVM.Nombre;
                bodega.Region = bodegaVM.Region;
                bodega.Pais = bodegaVM.Pais;
                await _bodegaService.Update(bodega);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _bodegaService.GetById(id);
            if (bodega == null)
            {
                return NotFound();
            }
            var bodegaVM = new BodegaVM
            {
                Id = bodega.Id,
                Nombre = bodega.Nombre,
                Region = bodega.Region,
                Pais = bodega.Pais,
            };
            return View(bodegaVM);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodega = await _bodegaService.GetById(id);
            if (bodega != null)
            {
                await _bodegaService.Delete(bodega);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BodegaExists(int id)
        {
            return _bodegaService.GetById(id) != null;
        }
    }
}
