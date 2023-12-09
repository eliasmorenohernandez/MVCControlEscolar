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
    public class EstatusAcreditacionesController : Controller
    {
        private readonly MvccontrolEscolarContext _context;

        public EstatusAcreditacionesController(MvccontrolEscolarContext context)
        {
            _context = context;
        }

        // GET: EstatusAcreditaciones
        public async Task<IActionResult> Index()
        {
              return _context.EstatusAcreditacions != null ? 
                          View(await _context.EstatusAcreditacions.ToListAsync()) :
                          Problem("Entity set 'MvccontrolEscolarContext.EstatusAcreditacions'  is null.");
        }

        // GET: EstatusAcreditaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstatusAcreditacions == null)
            {
                return NotFound();
            }

            var estatusAcreditacion = await _context.EstatusAcreditacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatusAcreditacion == null)
            {
                return NotFound();
            }

            return View(estatusAcreditacion);
        }

        // GET: EstatusAcreditaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstatusAcreditaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Status")] EstatusAcreditacion estatusAcreditacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estatusAcreditacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estatusAcreditacion);
        }

        // GET: EstatusAcreditaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstatusAcreditacions == null)
            {
                return NotFound();
            }

            var estatusAcreditacion = await _context.EstatusAcreditacions.FindAsync(id);
            if (estatusAcreditacion == null)
            {
                return NotFound();
            }
            return View(estatusAcreditacion);
        }

        // POST: EstatusAcreditaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Status")] EstatusAcreditacion estatusAcreditacion)
        {
            if (id != estatusAcreditacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estatusAcreditacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstatusAcreditacionExists(estatusAcreditacion.Id))
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
            return View(estatusAcreditacion);
        }

        // GET: EstatusAcreditaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstatusAcreditacions == null)
            {
                return NotFound();
            }

            var estatusAcreditacion = await _context.EstatusAcreditacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatusAcreditacion == null)
            {
                return NotFound();
            }

            return View(estatusAcreditacion);
        }

        // POST: EstatusAcreditaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstatusAcreditacions == null)
            {
                return Problem("Entity set 'MvccontrolEscolarContext.EstatusAcreditacions'  is null.");
            }
            var estatusAcreditacion = await _context.EstatusAcreditacions.FindAsync(id);
            if (estatusAcreditacion != null)
            {
                _context.EstatusAcreditacions.Remove(estatusAcreditacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstatusAcreditacionExists(int id)
        {
          return (_context.EstatusAcreditacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
