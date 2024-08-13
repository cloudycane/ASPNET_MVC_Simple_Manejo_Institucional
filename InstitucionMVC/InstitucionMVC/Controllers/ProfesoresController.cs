using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstitucionMVC.Data;
using InstitucionMVC.Models;

namespace InstitucionMVC.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var profesores = await _context.Profesores.Select(p => new ProfesoresViewModel
                {
                ProfesorId = p.ProfesorId, 
                Nombre_Profesor = p.Nombre,
                Asignatura_Id = p.Asignatura_Id,
                Nombre_Asignatura = _context.Asignaturas.Where(a => a.Asignatura_Id == p.Asignatura_Id).Select(a => a.Nombre_Asignatura).FirstOrDefault()

            }).ToListAsync();
            return View(profesores);
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesores = await _context.Profesores
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesores == null)
            {
                return NotFound();
            }

            return View(profesores);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesorId,Nombre,Apellidos,Direccion,Correo_Electronico,Num_Telefono,Tarjeta_Credito,Asignatura_Id")] Profesores profesores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesores);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesores = await _context.Profesores.FindAsync(id);
            if (profesores == null)
            {
                return NotFound();
            }
            return View(profesores);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesorId,Nombre,Apellidos,Direccion,Correo_Electronico,Num_Telefono,Tarjeta_Credito,Asignatura_Id")] Profesores profesores)
        {
            if (id != profesores.ProfesorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoresExists(profesores.ProfesorId))
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
            return View(profesores);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesores = await _context.Profesores
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesores == null)
            {
                return NotFound();
            }

            return View(profesores);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesores = await _context.Profesores.FindAsync(id);
            if (profesores != null)
            {
                _context.Profesores.Remove(profesores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoresExists(int id)
        {
            return _context.Profesores.Any(e => e.ProfesorId == id);
        }
    }
}
