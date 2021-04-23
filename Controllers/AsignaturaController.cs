using System;
using System.Linq;
using Dotnet_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dotnet_ASP.NET.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultiAsignatura()
        {
            // var listaAsignaturas = new List<Asignatura>() {
            //     new Asignatura {
            //     Nombre = "Matemáticas",
            //     Id = Guid.NewGuid ().ToString ()
            //     },
            //     new Asignatura {
            //     Nombre = "Educación Física",
            //     Id = Guid.NewGuid ().ToString ()
            //     },
            //     new Asignatura {
            //     Nombre = "Castellano",
            //     Id = Guid.NewGuid ().ToString ()
            //     },
            //     new Asignatura {
            //     Nombre = "Ciencias Naturales",
            //     Id = Guid.NewGuid ().ToString ()
            //     },
            //     new Asignatura {
            //     Nombre = "Programacion",
            //     Id = Guid.NewGuid ().ToString ()
            //     }
            // };

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas);
        }
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}