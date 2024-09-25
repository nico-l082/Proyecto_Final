using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Models;
using Proyecto_Final.Models.Clases;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace Proyecto_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ProyectoFinalContext db = new ProyectoFinalContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Usuario usuario)
        {
            var checkLogin = db.Usuarios.Where(x => x.Email.Equals(usuario.Email)
            && x.Contraseña.Equals(usuario.Contraseña))
                .FirstOrDefault();

            if (checkLogin != null)
            {
                HttpContext.Session.SetString("email", usuario.Email.ToString());
                HttpContext.Session.SetString("clave", usuario.Contraseña.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Email o clave incorrectas";
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Usuario usuario)
        {
            if(db.Usuarios.Any(x => x.Email == usuario.Email))
            {
                
                ViewBag.Notification = "Esta cuenta ya existe";
                return View();
            }else
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                HttpContext.Session.SetString("email", usuario.Email.ToString());
                HttpContext.Session.SetString("contraseña", usuario.Contraseña.ToString());
                HttpContext.Session.SetString("nombreUsuario", usuario.NombreUsuario.ToString());

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
