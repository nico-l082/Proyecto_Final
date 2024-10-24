using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Proyecto_Final.Models;
using Proyecto_Final.Models.Clases;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Nosotros()
        {
            return View();
        }
        public IActionResult MisJuegos()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Models.Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Contrase�a))
            {
                ViewBag.Notification = "Por favor, ingrese un email y una contrase�a v�lidos.";
                return View();
            }

            // Verificar si es un administrador
            var checkAdmin = db.Admins
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contrase�a.Equals(usuario.Contrase�a));

            if (checkAdmin != null)
            {
                // Iniciar sesi�n como administrador
                HttpContext.Session.SetString("email", checkAdmin.Email);
                HttpContext.Session.SetString("nombreUsuario", checkAdmin.Nombre);
                HttpContext.Session.SetString("rol", "Admin");

                return RedirectToAction("Index", "Home"); // Redirigir al panel de administraci�n
            }

            // Verificar si es un usuario com�n
            var checkUsuario = db.Usuarios
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contrase�a.Equals(usuario.Contrase�a));

            if (checkUsuario != null)
            {
                // Iniciar sesi�n como usuario com�n
                HttpContext.Session.SetString("email", checkUsuario.Email);
                HttpContext.Session.SetString("nombreUsuario", checkUsuario.NombreUsuario);
                HttpContext.Session.SetString("rol", "Usuario");

                return RedirectToAction("Index", "Home"); // Redirigir al �rea de usuario
            }

            // Si no es ni administrador ni usuario, mostrar error
            ViewBag.Notification = "Email o clave incorrectas";
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Models.Usuario usuario)
        {
            if (db.Usuarios.Any(x => x.Email == usuario.Email))
            {

                ViewBag.Notification = "Esta cuenta ya existe";
                return View();
            }
            else
            {

                db.Usuarios.Add(usuario);
                db.SaveChanges();


                HttpContext.Session.SetString("email", usuario.Email);
                HttpContext.Session.SetString("contrase�a", usuario.Contrase�a);
                HttpContext.Session.SetString("nombreUsuario", usuario.NombreUsuario);


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


        public IActionResult Cs2()
        {
            return View("Pesta�a_Venta/cs2");
        }
        public IActionResult BuyNow()
        {
            return View("Pesta�a_Venta/BuyNow");
        }

        
    }
}
