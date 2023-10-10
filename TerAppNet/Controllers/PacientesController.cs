using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerAppNet.Models;

namespace TerAppNet.Controllers
{
    public class PacientesController : Controller
    {
        private readonly MyDbContext _context;

        public PacientesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
              return _context.Pacientes != null ? 
                          View(await _context.Pacientes.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Pacientes'  is null.");
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Paciente_Id == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Paciente_Id,Nombre,Apellido,Telefono,Correo,Historial_medico,Receta_Medica,Duracion_Rec,FotoPerfil")] PacienteModel pacienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteModel);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.Pacientes.FindAsync(id);
            if (pacienteModel == null)
            {
                return NotFound();
            }
            return View(pacienteModel);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Paciente_Id,Nombre,Apellido,Telefono,Correo,Historial_medico,Receta_Medica,Duracion_Rec,FotoPerfil")] PacienteModel pacienteModel)
        {
            if (id != pacienteModel.Paciente_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteModelExists(pacienteModel.Paciente_Id))
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
            return View(pacienteModel);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.Paciente_Id == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'MyDbContext.Pacientes'  is null.");
            }
            var pacienteModel = await _context.Pacientes.FindAsync(id);
            if (pacienteModel != null)
            {
                _context.Pacientes.Remove(pacienteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteModelExists(int id)
        {
          return (_context.Pacientes?.Any(e => e.Paciente_Id == id)).GetValueOrDefault();
        }
    }
}
