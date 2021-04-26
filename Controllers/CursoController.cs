using System;
using System.Linq;
using Dotnet_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_ASP.NET.Controllers
{
    public class CursoController : Controller
    {
        // public IActionResult Index()
        // {
        //     return View(_context.Alumnos.FirstOrDefault());
        // }


        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var curso = from cur in _context.Cursos
                            where cur.Id == id
                            select cur;
                return View(curso.SingleOrDefault());

            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }

        }

        public IActionResult MultiCurso()
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Cursos);
        }

        public IActionResult Create()
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        // AQUI LE ESTAS DICIENDO QUE SOLO DEBE FUNCIONAR CUANDO LE LLAMEN POR HTTP POST, OSEA ENVIO DE FORMULARIO
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            // var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                //adicionar a la bd el curso
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }

        }
        [HttpGet]
        //EDICION DEL CURSO
        public IActionResult Edit(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            var curso = from cur in _context.Cursos
                        where cur.Id == id
                        select cur;
            return View(curso.SingleOrDefault());
        }
        [HttpPost]
        //EDICION DEL CURSO
        public IActionResult Edit(Curso curso)
        {

            ViewBag.Fecha = DateTime.Now;
            //va a funcionar si nuestro modelo es valido, de lo contrario te manda a la misma vista
            if (ModelState.IsValid)
            {
                _context.Entry(curso).State = EntityState.Modified;
                _context.SaveChanges();
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
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
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

    }
}