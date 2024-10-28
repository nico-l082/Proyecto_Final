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
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;
using iText.Html2pdf;
using OfficeOpenXml;
using Paragraph = iTextSharp.text.Paragraph;
using Document = iTextSharp.text.Document;

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
            var juegos = db.Juegos.ToList(); 
            return View(juegos); 
        }

        public IActionResult Nosotros()
        { 
            return View(); 
        }
        public IActionResult Soporte()
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


        public IActionResult GestionarUsuarios()
        {
           
            var usuarios = db.Usuarios.ToList();

            return View(usuarios);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            return RedirectToAction("GestionarUsuarios");
        }


        




        public IActionResult DownloadProductPdf(int id)
        {
            var juego = db.Juegos.FirstOrDefault(j => j.IdJuegos == id);
            if (juego == null)
            {
                return NotFound();
            }

            using (var stream = new MemoryStream())
            {
                var document = new Document(PageSize.A4);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream).CloseStream = false;
                document.Open();

                document.Add(new Paragraph("Detalle del Producto"));
                document.Add(new Paragraph($"Nombre: {juego.Nombre}"));
                document.Add(new Paragraph($"Descripción: {juego.Descripcion}"));
                document.Add(new Paragraph($"Género: {juego.Genero}"));
                document.Add(new Paragraph($"Precio: ${juego.Precio}"));
                document.Add(new Paragraph($"Desarrolladora: {juego.Desarrolladora}"));

                document.Close();

                return File(stream.ToArray(), "application/pdf", $"{juego.Nombre}_detalle.pdf");
            }
        }

        public IActionResult DownloadAllUsersPdf()
        {
            var usuarios = db.Usuarios.ToList();
            if (usuarios == null || !usuarios.Any())
            {
                return NotFound("No hay usuarios disponibles para descargar.");
            }

            using (var stream = new MemoryStream())
            {
                var document = new Document(PageSize.A4);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream).CloseStream = false;
                document.Open();

                document.Add(new Paragraph("Lista de Usuarios"));
                document.Add(new Paragraph("----------------------------------------------------------"));

                foreach (var usuario in usuarios)
                {
                    document.Add(new Paragraph($"Nombre: {usuario.NombreUsuario}"));
                    document.Add(new Paragraph($"Email: {usuario.Email}"));
                    document.Add(new Paragraph("----------------------------------------------------------"));                                    
                }

                document.Close();

                return File(stream.ToArray(), "application/pdf", "lista_usuarios.pdf");
            }
        }


        public IActionResult DownloadProductPdf2(int id)
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuarios == id);
            if (usuario == null)
            {
                return NotFound();
            }

            using (var stream = new MemoryStream())
            {
              
                var document = new Document(PageSize.A4);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream).CloseStream = false;
                document.Open();

              
                document.Add(new Paragraph("Detalle del Usuario"));
                document.Add(new Paragraph($"Nombre de Usuario: {usuario.NombreUsuario}"));
                document.Add(new Paragraph($"Email: {usuario.Email}"));

                document.Close();

                return File(stream.ToArray(), "application/pdf", $"{usuario.NombreUsuario}_detalle.pdf");
            }
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

       
            var checkAdmin = db.Admins
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contraseña.Equals(usuario.Contraseña));

            if (checkAdmin != null)
            {
            
                HttpContext.Session.SetString("email", checkAdmin.Email);
                HttpContext.Session.SetString("nombreUsuario", checkAdmin.Nombre);
                HttpContext.Session.SetString("rol", "Admin");

                return RedirectToAction("Index", "Home"); 
            }

           
            var checkUsuario = db.Usuarios
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contraseña.Equals(usuario.Contraseña));

            if (checkUsuario != null)
            {
               
                HttpContext.Session.SetString("email", checkUsuario.Email);
                HttpContext.Session.SetString("nombreUsuario", checkUsuario.NombreUsuario);
                HttpContext.Session.SetString("rol", "Usuario");

                return RedirectToAction("Index", "Home"); 
            }

            
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
            return View("Pestaña_Juegos/cs2");
        }
        public IActionResult BuyNow(int id) 
        {
            var juego = db.Juegos.Find(id);
            if (juego == null)
            {
                return NotFound();
            }
            return View(juego);
        }

     
        [HttpPost]
        public IActionResult BuyNow() 
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Success"); 
            }

            return View(); 
        }














    }
}
