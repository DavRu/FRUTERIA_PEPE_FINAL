using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FRUTERIA.Data;
using FRUTERIA.Models;

namespace FRUTERIA.Views.FRUTERIA_PEPES
{
    public class FRUTERIA_PEPESController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FRUTERIA_PEPESController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FRUTERIA_PEPES
        public async Task<IActionResult> Index()
        {
            return View(await _context.FRUTERIA_PEPE.ToListAsync());
        }

        // GET: FRUTERIA_PEPES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fRUTERIA_PEPE = await _context.FRUTERIA_PEPE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fRUTERIA_PEPE == null)
            {
                return NotFound();
            }

            return View(fRUTERIA_PEPE);
        }

        // GET: FRUTERIA_PEPES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FRUTERIA_PEPES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] FRUTERIA_PEPE fRUTERIA_PEPE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fRUTERIA_PEPE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fRUTERIA_PEPE);
        }

        // GET: FRUTERIA_PEPES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fRUTERIA_PEPE = await _context.FRUTERIA_PEPE.FindAsync(id);
            if (fRUTERIA_PEPE == null)
            {
                return NotFound();
            }
            return View(fRUTERIA_PEPE);
        }

        // POST: FRUTERIA_PEPES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] FRUTERIA_PEPE fRUTERIA_PEPE)
        {
            if (id != fRUTERIA_PEPE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fRUTERIA_PEPE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FRUTERIA_PEPEExists(fRUTERIA_PEPE.Id))
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
            return View(fRUTERIA_PEPE);
        }

        // GET: FRUTERIA_PEPES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fRUTERIA_PEPE = await _context.FRUTERIA_PEPE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fRUTERIA_PEPE == null)
            {
                return NotFound();
            }

            return View(fRUTERIA_PEPE);
        }

        // POST: FRUTERIA_PEPES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fRUTERIA_PEPE = await _context.FRUTERIA_PEPE.FindAsync(id);
            _context.FRUTERIA_PEPE.Remove(fRUTERIA_PEPE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FRUTERIA_PEPEExists(int id)
        {
            return _context.FRUTERIA_PEPE.Any(e => e.Id == id);
        }
    }
}
