using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCControlEscolar.Models;

namespace MVCControlEscolar.Controllers
{
    public class EstatusRegistrosController : Controller
    {
        private readonly MvccontrolEscolarContext _context;

        public EstatusRegistrosController(MvccontrolEscolarContext context)
        {
            _context = context;
        }

        // GET: EstatusRegistros
        public async Task<IActionResult> Index()
        {
              return _context.EstatusRegistros != null ? 
                          View(await _context.EstatusRegistros.ToListAsync()) :
                          Problem("Entity set 'MvccontrolEscolarContext.EstatusRegistros'  is null.");
        }

        // GET: EstatusRegistros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstatusRegistros == null)
            {
                return NotFound();
            }

            var estatusRegistro = await _context.EstatusRegistros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatusRegistro == null)
            {
                return NotFound();
            }

            return View(estatusRegistro);
        }

        // GET: EstatusRegistros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstatusRegistros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Status")] EstatusRegistro estatusRegistro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estatusRegistro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estatusRegistro);
        }

        // GET: EstatusRegistros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstatusRegistros == null)
            {
                return NotFound();
            }

            var estatusRegistro = await _context.EstatusRegistros.FindAsync(id);
            if (estatusRegistro == null)
            {
                return NotFound();
            }
            return View(estatusRegistro);
        }

        // POST: EstatusRegistros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Status")] EstatusRegistro estatusRegistro)
        {
            if (id != estatusRegistro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estatusRegistro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstatusRegistroExists(estatusRegistro.Id))
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
            return View(estatusRegistro);
        }

        // GET: EstatusRegistros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstatusRegistros == null)
            {
                return NotFound();
            }

            var estatusRegistro = await _context.EstatusRegistros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatusRegistro == null)
            {
                return NotFound();
            }

            return View(estatusRegistro);
        }

        // POST: EstatusRegistros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstatusRegistros == null)
            {
                return Problem("Entity set 'MvccontrolEscolarContext.EstatusRegistros'  is null.");
            }
            var estatusRegistro = await _context.EstatusRegistros.FindAsync(id);
            if (estatusRegistro != null)
            {
                _context.EstatusRegistros.Remove(estatusRegistro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstatusRegistroExists(int id)
        {
          return (_context.EstatusRegistros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
