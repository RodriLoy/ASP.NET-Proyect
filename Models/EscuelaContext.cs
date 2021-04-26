using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Dotnet_ASP.NET.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        // SOBRESCRIBIENDO LA CREACIÓN DE BASE DE DATOS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //llamo el mismo modelo que estoy sobreescribiendo
            base.OnModelCreating(modelBuilder);
            //luego haga lo que yo quiero 
            var escuela = new Escuela();
            escuela.Id = Guid.NewGuid().ToString();
            escuela.AnioDeCreacion = 2005;
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Av Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            //Cargar cursos de la escuela
            var cursos = CargarCursos(escuela);
            //x cada curso cargar asignaturas 
            var asignaturas = CargarAsignaturas(cursos);
            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            //Sembrar al a BD ESCUELA
            modelBuilder.Entity<Escuela>().HasData(escuela);
            //Sembrar a la BD CURSOS //RECUERDA QUE EL HASDATA SOLO ACEPTA ARRAY, DEBES CONVERTIR EXPLICITAMENTE CURSOS EN UN ARRAY
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            //Sembrar A LA BD ASIGNATURAS
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            //Sembrar A LA BD ALUMNOS
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());

            // modelBuilder.Entity<Asignatura>().HasData(
            //     new Asignatura
            //     {
            //         Nombre = "Matemáticas",
            //         Id = Guid.NewGuid().ToString()
            //     },
            //     new Asignatura
            //     {
            //         Nombre = "Educación Física",
            //         Id = Guid.NewGuid().ToString()
            //     },
            //     new Asignatura
            //     {
            //         Nombre = "Castellano",
            //         Id = Guid.NewGuid().ToString()
            //     },
            //     new Asignatura
            //     {
            //         Nombre = "Ciencias Naturales",
            //         Id = Guid.NewGuid().ToString()
            //     },
            //     new Asignatura
            //     {
            //         Nombre = "Programacion",
            //         Id = Guid.NewGuid().ToString()
            //     }
            // );
            // // se tiene que poner TOARRAY porque el metodo es una lista y forzosamente para el hasdata no se puede eso, se tiene que convertir en array
            // modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray());
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }


        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmplist = new List<Asignatura> {
                    new Asignatura { Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Matemáticas" },
                    new Asignatura { Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Educación Física" },
                    new Asignatura { Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Castellano" },
                    new Asignatura { Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Ciencias Naturales" },
                    new Asignatura { Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre = "Programacion" }
                };
                listaCompleta.AddRange(tmplist);
                // curso.Asignaturas = tmplist;
            }
            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                new Curso{
                          Nombre = "101",
                          Id = Guid.NewGuid().ToString(),
                          Jornada = TiposJornada.Mañana,
                          EscuelaId = escuela.Id,
                          Dirección = "Avenida siempre viva"},
                new Curso{
                            Nombre = "201",
                            Id = Guid.NewGuid().ToString(),
                            Jornada = TiposJornada.Mañana,
                            EscuelaId = escuela.Id,
                            Dirección = "Avenida siempre viva"},
                new Curso{Nombre = "301", Id = Guid.NewGuid().ToString(), Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id, Dirección = "Avenida siempre viva"},
                new Curso{Nombre = "401", Id = Guid.NewGuid().ToString(), Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id, Dirección = "Avenida siempre viva"},
                new Curso{Nombre = "501", Id = Guid.NewGuid().ToString(), Jornada = TiposJornada.Mañana, EscuelaId = escuela.Id, Dirección = "Avenida siempre viva"}
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso Curso, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = Curso.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
    }
}