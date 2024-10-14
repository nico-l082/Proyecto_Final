using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Models.Usuario usuario)
        {
            // Verificar que el objeto usuario no sea null
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Contraseña))
            {
                ViewBag.Notification = "Por favor, ingrese un email y una contraseña válidos.";
                return View();
            }

            // Buscar el usuario en la base de datos
            var checkLogin = db.Usuarios
                .FirstOrDefault(x => usuario.Email.Equals(usuario.Email) && usuario.Contraseña.Equals(usuario.Contraseña));

            if (checkLogin != null)
            {
                // Almacenar los datos del usuario en la sesión
                HttpContext.Session.SetString("email", checkLogin.Email); 
                HttpContext.Session.SetString("clave", checkLogin.Contraseña); // 
                HttpContext.Session.SetString("nombreUsuario", checkLogin.NombreUsuario);

                return RedirectToAction("Index", "Home"); // Redirigir a la página de inicio
            }
            else
            {
                ViewBag.Notification = "Email o clave incorrectas";
            }

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
            // Verificar si el email ya está registrado en la base de datos
            if (db.Usuarios.Any(x => x.Email == usuario.Email))
            {
                // Si el email ya existe, se muestra un mensaje de notificación
                ViewBag.Notification = "Esta cuenta ya existe";
                return View(usuario); // Devolver el objeto usuario para mantener los valores ingresados
            }
            else
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                HttpContext.Session.SetString("email", usuario.Email);
                HttpContext.Session.SetString("contraseña", usuario.Contraseña); 
                HttpContext.Session.SetString("nombreUsuario", usuario.NombreUsuario);

                // Redirigir al Index del HomeController
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
