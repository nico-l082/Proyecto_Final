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
using System.Data.Entity.Infrastructure;
using Proyecto_Final.Data;

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
        

        
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(Models.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("GestionarUsuarios");
            }
            return View(usuario);
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

                try
                {
                    string logoPath = juego.ImagenUrl; 

                    Console.WriteLine($"Ruta del logo: {logoPath}");

                    if (logoPath.StartsWith("~/"))
                    {
                        logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", logoPath.Substring(2));
                    }

                    if (!System.IO.File.Exists(logoPath))
                    {
                        throw new System.IO.FileNotFoundException("El archivo de imagen no se encontr� en la ruta especificada.");
                    }

                    var logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(140f, 120f); 
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    document.Add(logo);
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    document.Add(new Paragraph("La imagen no se pudo encontrar: " + ex.Message));
                }
                catch (System.UriFormatException ex)
                {
                    document.Add(new Paragraph("La URL de la imagen es inv�lida: " + ex.Message));
                }
                catch (Exception ex)
                {
                    document.Add(new Paragraph("Error al cargar la imagen: " + ex.Message));
                }

                document.Add(new Paragraph("Detalle del Producto"));
                document.Add(new Paragraph($"Nombre: {juego.Nombre}"));
                document.Add(new Paragraph($"Descripci�n: {juego.Descripcion}"));
                document.Add(new Paragraph($"G�nero: {juego.Genero}"));
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
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Contrase�a))
            {
                ViewBag.Notification = "Por favor, ingrese un email y una contrase�a v�lidos.";
                return View();
            }

       
            var checkAdmin = db.Admins
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contrase�a.Equals(usuario.Contrase�a));

            if (checkAdmin != null)
            {
            
                HttpContext.Session.SetString("email", checkAdmin.Email);
                HttpContext.Session.SetString("nombreUsuario", checkAdmin.Nombre);
                HttpContext.Session.SetString("rol", "Admin");

                return RedirectToAction("Index", "Home"); 
            }

           
            var checkUsuario = db.Usuarios
                .FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Contrase�a.Equals(usuario.Contrase�a));

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
                HttpContext.Session.SetString("contrase�a", usuario.Contrase�a);
                HttpContext.Session.SetString("nombreUsuario", usuario.NombreUsuario);


                return RedirectToAction("LogIn", "Home");
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

        [HttpPost]
        public IActionResult BuyNow(int id)
        {
            string userIdString = HttpContext.Session.GetString("IdUsuarios");
            int userId = int.Parse(userIdString); 

            var compraExistente = db.UsuarioJuegos
                .FirstOrDefault(uj => uj.UserId == userId && uj.JuegoId == id);

            if (compraExistente == null)
            {
                var nuevaCompra = new UsuarioJuego
                {
                    UserId = userId,
                    JuegoId = id,
                    FechaCompra = DateTime.Now
                };

                db.UsuarioJuegos.Add(nuevaCompra);
                db.SaveChanges();
            }

            return RedirectToAction("MisJuegos");
        }







        [HttpPost]
        public IActionResult Actualizar(Models.Usuario usuario)
        {
            if (usuario.IdUsuarios == 0) 
            {
                return View("Error", new ErrorViewModel { ErrorMessage = "ID de usuario inv�lido." });
            }

            var usuarioExistente = db.Usuarios.FirstOrDefault(u => u.IdUsuarios == usuario.IdUsuarios);
            if (usuarioExistente != null)
            {
                usuarioExistente.NombreUsuario = usuario.NombreUsuario;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Contrase�a = usuario.Contrase�a;

                db.SaveChanges();
                return RedirectToAction("GestionarUsuarios", "Home");
            }

            return View("Error", new ErrorViewModel { ErrorMessage = "Usuario no encontrado." });
        }

        public IActionResult EditarUsuario(int id)
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuarios == id);
            if (usuario == null)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = "Usuario no encontrado." });
            }

            return View(usuario);
        }


        public IActionResult GestionarJuegos()
        {
            var juegos = db.Juegos.ToList();

            return View(juegos);
        }

        public IActionResult EditarJuego(int id)
        {
            var juego = db.Juegos.FirstOrDefault(j => j.IdJuegos == id);

            if (juego == null)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = "Juego no encontrado." });
            }

            return View(juego);
        }

        [HttpPost]
        public IActionResult EditarJuego(Proyecto_Final.Models.Juego juego)
        {
            if (ModelState.IsValid)
            {
                var juegoExistente = db.Juegos.FirstOrDefault(j => j.IdJuegos == juego.IdJuegos);

                if (juegoExistente != null)
                {
                    juegoExistente.Nombre = juego.Nombre;
                    juegoExistente.Descripcion = juego.Descripcion;
                    juegoExistente.Genero = juego.Genero;
                    juegoExistente.Precio = juego.Precio;

                    db.SaveChanges();

                    return RedirectToAction("GestionarJuegos");
                }
            }

            return View(juego);
        }
        public IActionResult EliminarJuego(int id)
        {
            var juego = db.Juegos.FirstOrDefault(j => j.IdJuegos == id);

            if (juego != null)
            {
                db.Juegos.Remove(juego);
                db.SaveChanges();

                return RedirectToAction("GestionarJuegos");
            }

            return View("Error", new ErrorViewModel { ErrorMessage = "Juego no encontrado." });
        }

        public IActionResult AgregarJuego()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AgregarJuegos(Models.Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Juegos.Add(juego);
                db.SaveChanges();
                
                return RedirectToAction("GestionarJuegos");
            }

            return View(juego);
        }
        public IActionResult MisJuegos()
        {
            string userIdString = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = int.Parse(userIdString);

            var juegosComprados = db.UsuarioJuegos
                .Where(uj => uj.UserId == userId)
                .Select(uj => uj.Juego)
                .ToList();

            return View(juegosComprados);
        }
    }
}
