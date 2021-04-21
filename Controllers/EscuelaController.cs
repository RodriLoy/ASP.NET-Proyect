using System;
using Dotnet_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_ASP.NET.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Av Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            ViewBag.CosaDinamica = "La Monja";
            return View(escuela);
        }
    }
}