using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Proyecto_Final.Models;
using Proyecto_Final.Data;
using System.Linq;

namespace Proyecto_Final.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        ProyectoFinalContext db = new ProyectoFinalContext();

        public UsuariosController()
        {
            _context = new ApplicationDbContext();
        }


        public IActionResult DownloadAllUsersExcel()
        {
            // Establece el contexto de licencia
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Recupera todos los usuarios de la base de datos
            var usuarios = db.Usuarios.ToList();
            if (usuarios == null || !usuarios.Any())
            {
                return NotFound("No hay usuarios disponibles para descargar.");
            }

            // Crea un nuevo paquete de Excel
            using (var package = new ExcelPackage())
            {
                // Agrega una nueva hoja de trabajo
                var worksheet = package.Workbook.Worksheets.Add("Lista de Usuarios");

                // Agrega los encabezados de columna
                worksheet.Cells[1, 1].Value = "Nombre";
                worksheet.Cells[1, 2].Value = "Email";

                // Agrega los datos de los usuarios
                int row = 2;
                foreach (var usuario in usuarios)
                {
                    worksheet.Cells[row, 1].Value = usuario.NombreUsuario;
                    worksheet.Cells[row, 2].Value = usuario.Email;
                    row++;
                }

                // Ajusta el ancho de las columnas
                worksheet.Cells.AutoFitColumns();

                // Prepara el archivo para ser descargado
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "lista_usuarios.xlsx");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index"); // Redirige a la lista de usuarios después de agregar
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Actualizar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Update(usuario);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(usuario); 
        }
    }
}
