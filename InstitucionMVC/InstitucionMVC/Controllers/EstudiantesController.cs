using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstitucionMVC.Data;
using InstitucionMVC.Models;
using Microsoft.VisualBasic;

namespace InstitucionMVC.Controllers
{
    
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Estudiantes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiantes.ToListAsync());
        }

        // View de MatriculacionExitoso

        public IActionResult MatriculacionExitoso(int id)
        {
            // Pass the EstudianteId to the view
            ViewBag.EstudianteId = id;
            return View();
        }

        [HttpGet]
        public IActionResult ExportUserDetails()
        {
            // Create a simple text-based PDF content
            var content = "Hello, this is a simple PDF file generated without external libraries.";

            // Define the byte array to hold the PDF content
            byte[] pdfBytes;

            using (var memoryStream = new MemoryStream())
            {
                // Write the text content as bytes into the memory stream
                using (var writer = new StreamWriter(memoryStream))
                {
                    writer.Write(content);
                    writer.Flush();
                    pdfBytes = memoryStream.ToArray();
                }
            }

            // Return the PDF as a FileResult
            return File(pdfBytes, "application/pdf", "SimplePdf.pdf");
        }
    

    // GET: Estudiantes/Details/5
    [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("EstudianteId,Nombre,Apellidos,Edad,Fecha_Nacimiento,Direccion,Correo_Electronico,Ultimo_Estudio_Realizado")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction("MatriculacionExitoso");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudianteId,Nombre,Apellidos,Edad,Fecha_Nacimiento,Direccion,Correo_Electronico,Ultimo_Estudio_Realizado")] Estudiante estudiante)
        {
            if (id != estudiante.EstudianteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.EstudianteId))
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
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.EstudianteId == id);
        }
    }
}
