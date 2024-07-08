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
using System.Collections;

namespace FinalHerramientas.Controllers
{
    public class VinosController : Controller
    {
        private readonly IVinoService _vinoService;

        public VinosController(IVinoService vinoService)
        {
            _vinoService = vinoService;
        }

        // GET: Vino
        public async Task<IActionResult> Index(string filter)
        {
            var vinosVM = new VinoListVM();
            var vinos = await _vinoService.GetAll(filter);
            foreach (var vino in vinos)
            {
                var bodegaNombre = vino.Bodega == null ? "Sin bodega" : vino.Bodega.Nombre;
                vinosVM.vinos.Add(new VinoVM
                {
                    Id = vino.Id,
                    Nombre = vino.Nombre,
                    Año = vino.Año,
                    Variedad = vino.Variedad,
                    Precio = vino.Precio,
                    Stock = vino.Stock,
                    BodegaNombre = bodegaNombre
                });
            }

            return View(vinosVM);
        }

        // GET: Vino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _vinoService.GetById(id);
            if (vino == null)
            {
                return NotFound();
            }
            var bodegaNombre = vino.Bodega == null ? "Sin bodega" : vino.Bodega.Nombre;
            var vinoVM = new VinoVM
            {
                Id = vino.Id,
                Nombre = vino.Nombre,
                Año = vino.Año,
                Variedad = vino.Variedad,
                Precio = vino.Precio,
                Stock = vino.Stock,
                BodegaNombre = bodegaNombre,
            };
            return View(vinoVM);
        }

        // GET: Vino/Create
        public async Task<IActionResult> Create()
        {
            var bodegas = await _vinoService.GetAllBodegas();
            ViewData["Bodegas"] = new SelectList(bodegas, "Id", "Nombre");
            return View();
        }

        // POST: Vino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Año,Variedad,Precio,Stock,BodegaId")] VinoCreateVM vinoVM)
        {
            if (ModelState.IsValid)
            {
                var vino = new Vino
                {
                    Id = vinoVM.Id,
                    Nombre = vinoVM.Nombre,
                    Año = vinoVM.Año,
                    Variedad = vinoVM.Variedad,
                    Precio = vinoVM.Precio,
                    Stock = vinoVM.Stock,
                    BodegaID = vinoVM.BodegaId
                };
                await _vinoService.Create(vino);
                return RedirectToAction(nameof(Index));
            }
            return View(vinoVM);
        }

        // GET: Vino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _vinoService.GetById(id);
            if (vino == null)
            {
                return NotFound();
            }
            var bodegas = _vinoService.GetAllBodegas();

            ViewData["BodegaID"] = new SelectList((IEnumerable)bodegas, "Id", "Id", vino.BodegaID);
            var vinoVM = new VinoVM
            {
                Id = vino.Id,
                Nombre = vino.Nombre,
                Año = vino.Año,
                Variedad = vino.Variedad,
                Precio = vino.Precio,
                Stock = vino.Stock,
                BodegaNombre = vino.Bodega.Nombre
            };
            return View(vinoVM);
        }

        // POST: Vino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Año,Variedad,Precio,Stock,BodegaID")] VinoVM vinoVM)
        {
            if (id != vinoVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var vino = await _vinoService.GetById(id);
                if (vino == null) { return NotFound(); }
                vino.Id = vinoVM.Id;
                vino.Nombre = vinoVM.Nombre;
                vino.Año = vinoVM.Año;
                vino.Variedad = vinoVM.Variedad;
                vino.Precio = vinoVM.Precio;
                vino.Stock = vinoVM.Stock;
                vino.BodegaID = vinoVM.BodegaId;

                await _vinoService.Update(vino);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Vino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _vinoService.GetById(id);
            if (vino == null)
            {
                return NotFound();
            }
            var vinoVM = new VinoVM
            {
                Id = vino.Id,
                Nombre = vino.Nombre,
                Año = vino.Año,
                Variedad = vino.Variedad,
                Precio = vino.Precio,
                Stock = vino.Stock,
                BodegaNombre = vino.Bodega.Nombre
            };
            return View(vinoVM);
        }

        // POST: Vino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vino = await _vinoService.GetById(id);
            if (vino != null)
            {
                await _vinoService.Delete(vino);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
