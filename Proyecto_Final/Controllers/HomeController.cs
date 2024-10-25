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
using System.IO;
using System.Linq;
using iText.Html2pdf;

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
            var _usuarios = db.Usuarios.ToList();
            return View(_usuarios);
        }
        public IActionResult Nosotros()
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
            var usuario = db.Usuarios.Find(id); // Encuentra al usuario por ID
            if (usuario != null)
            {
                db.Usuarios.Remove(usuario); // Elimina el usuario
                db.SaveChanges(); // Guarda los cambios en la base de datos
            }
            return RedirectToAction("GestionarUsuarios"); // Redirige de nuevo a la lista de usuarios
        }


        public IActionResult DescargarPDF()
        {
            var usuarios = db.Usuarios.ToList();

            // Crear un stream para el PDF
            using (MemoryStream ms = new MemoryStream())
            {
                // Crear el documento PDF
                PdfWriter writer = new PdfWriter(ms);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc);

                // Agregar t�tulo al PDF
                document.Add(new Paragraph("Lista de Usuarios").SetFontSize(20));

                // Crear tabla para los datos de los usuarios
                Table table = new Table(3, true); // 3 columnas

                // Encabezados de la tabla
                table.AddCell("ID");
                table.AddCell("Nombre Usuario");
                table.AddCell("Email");

                // Rellenar la tabla con los datos de los usuarios
                foreach (var usuario in usuarios)
                {
                    table.AddCell(usuario.IdUsuarios.ToString());
                    table.AddCell(usuario.NombreUsuario);
                    table.AddCell(usuario.Email);
                }

                document.Add(table); // Agregar la tabla al documento

                // Cerrar el documento
                document.Close();

                // Devolver el PDF como archivo descargable
                return File(ms.ToArray(), "application/pdf", "ListaUsuarios.pdf");
            }
        }

        public IActionResult GenerateCS2Pdf()
        {
            // Ruta de la carpeta 'pdfs'
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs");
            var fileName = "CounterStrike2.pdf";
            var filePath = Path.Combine(folderPath, fileName);

            // Verifica si la carpeta 'pdfs' existe, si no, la crea
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Ruta absoluta de la imagen
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lib", "imagenes_juegos", "cs2.jpg");

            // HTML del contenido con imagen incluida
            var htmlContent = $@"
            <html>
            <head>
                <title>Counter Strike 2</title>
            </head>
            <body>
                <h1>Counter Strike 2</h1>
                <img src='file:///{imagePath}' alt='CS2' style='width: 300px;' />
                <sapn><br />
                    Counter-Strike 2 es la �ltima entrega de la ic�nica serie de juegos de disparos en primera persona (FPS) desarrollada por Valve Corporation. Lanzado en 2023 como una actualizaci�n masiva de Counter-Strike: Global Offensive (CS:GO), este juego mantiene la esencia del cl�sico Counter-Strike al tiempo que introduce mejoras significativas en gr�ficos, jugabilidad y mec�nicas.
                    <br />
                    <b style=""font-size:1.2rem;"">Caracter�sticas Clave:</b>
                    <ul>
                        <li>Gr�ficos Mejorados: Utiliza un nuevo motor gr�fico, Source 2, que proporciona entornos m�s detallados, efectos visuales mejorados y una experiencia m�s inmersiva.</li>
                        <li>Nuevas Mec�nicas de Juego: Introduce mec�nicas de juego mejoradas, como la posibilidad de lanzar armas, nuevos sistemas de movimiento y un enfoque en la f�sica para una jugabilidad m�s realista.</li>
                        <li>Mapas Actualizados: Incluye versiones reimaginadas de mapas cl�sicos junto con nuevos entornos dise�ados para aprovechar las capacidades gr�ficas avanzadas del motor.</li>
                        <li>Sistema de Jugabilidad Din�mico: Presenta cambios en la econom�a del juego y en la forma en que se distribuyen las armas y el equipo, ofreciendo una experiencia m�s estrat�gica.</li>
                        <li>Accesibilidad y Experiencia de Usuario: Mejora en la interfaz de usuario, as� como opciones de accesibilidad que hacen que el juego sea m�s amigable para nuevos jugadores, sin perder la profundidad que caracteriza a la serie.</li>
                        <li>Modos de Juego Variados: Adem�s de los cl�sicos modos de juego como ""Desactivaci�n de Bomba"" y ""Rescate de Rehenes"", incluye nuevas modalidades que fomentan la cooperaci�n y el juego competitivo.</li>
                        <li>Comunidad y Competitividad: Al igual que sus predecesores, Counter-Strike 2 sigue promoviendo una fuerte comunidad competitiva, con soporte para torneos y ligas, as� como herramientas para creadores de contenido y mods.</li>
                    </ul>
                    <b style=""font-size:1.2rem;"">Resumen:</b>
                    <br />
                    Counter-Strike 2 no solo es una continuaci�n de la serie, sino una reinvenci�n que busca atraer tanto a los veteranos de la saga como a nuevos jugadores. Con su enfoque en la estrategia, la precisi�n y el trabajo en equipo, promete ser una experiencia emocionante en el mundo de los eSports y los juegos de disparos en primera persona.
                </sapn>
            </body>
            </html>";

            // Crear el archivo PDF desde el HTML
            using (FileStream pdfDest = new FileStream(filePath, FileMode.Create))
            {
                ConverterProperties properties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(htmlContent, pdfDest, properties);
            }

            // Descargar el archivo PDF
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", fileName);
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
