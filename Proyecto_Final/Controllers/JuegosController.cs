using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Data;
using Proyecto_Final.Models;
using System.Linq;

namespace Proyecto_Final.Controllers
{
    public class JuegosController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public JuegosController(ProyectoFinalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var juegos = _context.Juegos.ToList();
            return View(juegos);
        }
    }
}
