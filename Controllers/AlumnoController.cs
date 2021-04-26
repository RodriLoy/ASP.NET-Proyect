using System;
using System.Linq;
using Dotnet_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_ASP.NET.Controllers
{
    public class AlumnoController : Controller
    {
        // public IActionResult Index()
        // {
        //     return View(_context.Alumnos.FirstOrDefault());
        // }


        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos
                             where alum.Id == id
                             select alum;
                return View(alumno.SingleOrDefault());

            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }

        }

        public IActionResult MultiAlumno()
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Alumnos);
        }
        // private List<Alumno> GenerarAlumnosAlAzar()
        // {
        //     string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        //     string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        //     string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        //     var listaAlumnos = from n1 in nombre1
        //                        from n2 in nombre2
        //                        from a1 in apellido1
        //                        select new Alumno { Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

        //     return listaAlumnos.OrderBy((al) => al.Id).ToList();
        // }
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.Fecha = DateTime.Now;

            //creando un nuevo selectlist en base a el objeto  cursos
            ViewBag.Cursos = new SelectList(_context.Alumnos, "Id", "Nombre");

            return View();
        }

        // AQUI LE ESTAS DICIENDO QUE SOLO DEBE FUNCIONAR CUANDO LE LLAMEN POR HTTP POST, OSEA ENVIO DE FORMULARIO
        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            if (ModelState.IsValid)
            {

                // var escuela = _context.Escuelas.FirstOrDefault();
                // var lista = new List<SelectListItem>();
                // foreach (var item in _context.Cursos)
                // {
                //     lista.Add(new SelectListItem
                //     {
                //         Text = item.Nombre,
                //         Value = item.Id
                //     });

                // }
                // ViewBag.Cursos = lista;
                //adicionar a la bd el asignatura
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "alumno Creado";
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }

        }
        [HttpGet]
        //EDICION DEL CURSO
        public IActionResult Edit(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            var alumno = from alum in _context.Alumnos
                         where alum.Id == id
                         select alum;

            return View(alumno.SingleOrDefault());
        }
        [HttpPost]
        //EDICION DEL CURSO
        public IActionResult Edit(Alumno alumno)
        {

            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            if (ModelState.IsValid)
            {
                _context.Entry(alumno).State = EntityState.Modified;
                _context.SaveChanges();
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var alumno = from alum in _context.Alumnos
                         where alum.Id == id
                         select alum;
            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            _context.Alumnos.Remove(alumno.SingleOrDefault());
            _context.SaveChanges();
            return View("MultiAsignatura");
        }

    }
}