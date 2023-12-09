﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCControlEscolar.Models;

namespace MVCControlEscolar.Controllers
{
    public class GruposController : Controller
    {
        private readonly MvccontrolEscolarContext _context;

        public GruposController(MvccontrolEscolarContext context)
        {
            _context = context;
        }

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            var mvccontrolEscolarContext = _context.Grupos.Include(g => g.IdEstatusRegistroNavigation).Include(g => g.IdMateriaNavigation).Include(g => g.IdProfesorNavigation);
            return View(await mvccontrolEscolarContext.ToListAsync());
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdEstatusRegistroNavigation)
                .Include(g => g.IdMateriaNavigation)
                .Include(g => g.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre");
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Nombre");
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "Id", "Nombre");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdProfesor,IdMateria,IdEstatusRegistro")] Grupo grupo)
        {
            if (1==1)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", grupo.IdEstatusRegistro);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Nombre", grupo.IdMateria);
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "Id", "Nombre", grupo.IdProfesor);
            return View(grupo);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", grupo.IdEstatusRegistro);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Nombre", grupo.IdMateria);
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "Id", "Nombre", grupo.IdProfesor);
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdProfesor,IdMateria,IdEstatusRegistro")] Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return NotFound();
            }

            if (1==1)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.Id))
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
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", grupo.IdEstatusRegistro);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Nombre", grupo.IdMateria);
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "Id", "Nombre" + " " + "PrimerApellido" + " " + "SegundoApellido", grupo.IdProfesor);
            return View(grupo);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdEstatusRegistroNavigation)
                .Include(g => g.IdMateriaNavigation)
                .Include(g => g.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grupos == null)
            {
                return Problem("Entity set 'MvccontrolEscolarContext.Grupos'  is null.");
            }
            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo != null)
            {
                _context.Grupos.Remove(grupo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
          return (_context.Grupos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
