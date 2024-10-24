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
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Contraseña))
            {
                ViewBag.Notification = "Por favor, ingrese un email y una contraseña válidos.";
                return View();
            }

            // Verificar si es un administrador
            var checkAdmin = db.Admins
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contraseña.Equals(usuario.Contraseña));

            if (checkAdmin != null)
            {
                // Iniciar sesión como administrador
                HttpContext.Session.SetString("email", checkAdmin.Email);
                HttpContext.Session.SetString("nombreUsuario", checkAdmin.Nombre);
                HttpContext.Session.SetString("rol", "Admin");

                return RedirectToAction("Index", "Home"); // Redirigir al panel de administración
            }

            // Verificar si es un usuario común
            var checkUsuario = db.Usuarios
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contraseña.Equals(usuario.Contraseña));

            if (checkUsuario != null)
            {
                // Iniciar sesión como usuario común
                HttpContext.Session.SetString("email", checkUsuario.Email);
                HttpContext.Session.SetString("nombreUsuario", checkUsuario.NombreUsuario);
                HttpContext.Session.SetString("rol", "Usuario");

                return RedirectToAction("Index", "Home"); // Redirigir al área de usuario
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
                HttpContext.Session.SetString("contraseña", usuario.Contraseña);
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
            return View("Pestaña_Venta/cs2");
        }
        public IActionResult BuyNow()
        {
            return View("Pestaña_Venta/BuyNow");
        }

        
    }
}
