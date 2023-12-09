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
    public class CalificacionesController : Controller
    {
        private readonly MvccontrolEscolarContext _context;

        public CalificacionesController(MvccontrolEscolarContext context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
            var mvccontrolEscolarContext = _context.Calificacions.Include(c => c.IdAlumnoNavigation).Include(c => c.IdEstatusAcreditacionNavigation).Include(c => c.IdEstatusRegistroNavigation).Include(c => c.IdGrupoNavigation);
            return View(await mvccontrolEscolarContext.ToListAsync());
        }

        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calificacions == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacions
                .Include(c => c.IdAlumnoNavigation)
                .Include(c => c.IdEstatusAcreditacionNavigation)
                .Include(c => c.IdEstatusRegistroNavigation)
                .Include(c => c.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre");
            ViewData["IdEstatusAcreditacion"] = new SelectList(_context.EstatusAcreditacions, "Id", "Nombre");
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre");
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "Id", "Nombre");
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAlumno,IdGrupo,CalificacionGrupo,IdEstatusAcreditacion,IdEstatusRegistro")] Calificacion calificacion)
        {
            if (1==1)
            {
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre", calificacion.IdAlumno);
            ViewData["IdEstatusAcreditacion"] = new SelectList(_context.EstatusAcreditacions, "Id", "Nombre", calificacion.IdEstatusAcreditacion);
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", calificacion.IdEstatusRegistro);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "Id", "Nombre", calificacion.IdGrupo);
            return View(calificacion);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calificacions == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre", calificacion.IdAlumno);
            ViewData["IdEstatusAcreditacion"] = new SelectList(_context.EstatusAcreditacions, "Id", "Nombre", calificacion.IdEstatusAcreditacion);
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", calificacion.IdEstatusRegistro);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "Id", "Nombre", calificacion.IdGrupo);
            return View(calificacion);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAlumno,IdGrupo,CalificacionGrupo,IdEstatusAcreditacion,IdEstatusRegistro")] Calificacion calificacion)
        {
            if (id != calificacion.Id)
            {
                return NotFound();
            }

            if (1==1)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionExists(calificacion.Id))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre", calificacion.IdAlumno);
            ViewData["IdEstatusAcreditacion"] = new SelectList(_context.EstatusAcreditacions, "Id", "Nombre", calificacion.IdEstatusAcreditacion);
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", calificacion.IdEstatusRegistro);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "Id", "Nombre", calificacion.IdGrupo);
            return View(calificacion);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calificacions == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacions
                .Include(c => c.IdAlumnoNavigation)
                .Include(c => c.IdEstatusAcreditacionNavigation)
                .Include(c => c.IdEstatusRegistroNavigation)
                .Include(c => c.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calificacions == null)
            {
                return Problem("Entity set 'MvccontrolEscolarContext.Calificacions'  is null.");
            }
            var calificacion = await _context.Calificacions.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificacions.Remove(calificacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionExists(int id)
        {
          return (_context.Calificacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
