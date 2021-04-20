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
            escuela.AñoFundación = 2005;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            return View(escuela);
        }
    }
}