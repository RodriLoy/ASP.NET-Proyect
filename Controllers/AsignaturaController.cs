using System;
using System.Linq;
using Dotnet_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_ASP.NET.Controllers
{
    public class AsignaturaController : Controller
    {
        //una sola asignatura sin importar cual
        // public IActionResult Index()
        // {
        //     return View(_context.Asignaturas.FirstOrDefault());
        // }
        //Para elegir en base al id de la asignatura


        //asignatura por enrutamiento
        // [Route("Asignatura/Index")]
        // [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var asignatura = from asig in _context.Asignaturas
                                 where asig.Id == Id
                                 select asig;
                return View(asignatura.SingleOrDefault());

            }
            else
            {
                return View("MultiAsignatura", _context.Asignaturas);
            }

        }
        //multiasignaturas
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

        public IActionResult Create()
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.Fecha = DateTime.Now;

            //creando un nuevo selectlist en base a el objeto  cursos
            ViewBag.Cursos = new SelectList(_context.Cursos, "Id", "Nombre");

            return View();
        }

        // AQUI LE ESTAS DICIENDO QUE SOLO DEBE FUNCIONAR CUANDO LE LLAMEN POR HTTP POST, OSEA ENVIO DE FORMULARIO
        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
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
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "asignatura Creada";
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }

        }
        [HttpGet]
        //EDICION DEL CURSO
        public IActionResult Edit(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            var asignatura = from asig in _context.Asignaturas
                             where asig.Id == id
                             select asig;

            //creando un nuevo selectlist en base a el objeto  cursos
            ViewBag.Cursos = new SelectList(_context.Cursos, "Id", "Nombre");

            return View(asignatura.SingleOrDefault());
        }
        [HttpPost]
        //EDICION DEL CURSO
        public IActionResult Edit(Asignatura asignatura)
        {

            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            if (ModelState.IsValid)
            {
                _context.Entry(asignatura).State = EntityState.Modified;
                _context.SaveChanges();
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var asignatura = from asig in _context.Asignaturas
                             where asig.Id == id
                             select asig;
            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            _context.Asignaturas.Remove(asignatura.SingleOrDefault());
            _context.SaveChanges();
            return View("MultiAsignatura");
        }


    }
}