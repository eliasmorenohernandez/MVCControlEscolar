using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCControlEscolar.Models;

namespace MVCControlEscolar.Controllers
{
    public class MateriasController : Controller
    {
        private readonly MvccontrolEscolarContext _context;

        public MateriasController(MvccontrolEscolarContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            var mvccontrolEscolarContext = _context.Materia.Include(m => m.IdEstatusRegistroNavigation);
            return View(await mvccontrolEscolarContext.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia
                .Include(m => m.IdEstatusRegistroNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre");
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clave,Nombre,Creditos,IdEstatusRegistro")] Materia materia)
        {
            if (1==1)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", materia.IdEstatusRegistro);
            return View(materia);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", materia.IdEstatusRegistro);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clave,Nombre,Creditos,IdEstatusRegistro")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (1==1)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
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
            ViewData["IdEstatusRegistro"] = new SelectList(_context.EstatusRegistros, "Id", "Nombre", materia.IdEstatusRegistro);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia
                .Include(m => m.IdEstatusRegistroNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materia == null)
            {
                return Problem("Entity set 'MvccontrolEscolarContext.Materia'  is null.");
            }
            var materia = await _context.Materia.FindAsync(id);
            if (materia != null)
            {
                _context.Materia.Remove(materia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return (_context.Materia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
