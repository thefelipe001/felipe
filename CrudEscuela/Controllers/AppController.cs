using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudEscuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Controllers
{
    public class AppController : Controller
    {
        EstudiantesDB estudiantesDB = new EstudiantesDB();
        public IActionResult Listado()
        {
            List<Estudiante> estudiante = new List<Estudiante>();
            estudiante = estudiantesDB.Todolosestudiantes().ToList();
            return View(estudiante);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear([Bind] Estudiante objestudiantes)
        {
            if (ModelState.IsValid) 
            {
                estudiantesDB.AgregarEstudiantes(objestudiantes);
                return RedirectToAction("Listado");
            }
            return View(objestudiantes);
        }
    }
}