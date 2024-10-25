using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Proyecto_Final.Models;
using Proyecto_Final.Data;

namespace Proyecto_Final.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

 
        public UsuariosController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult DescargarUsuariosExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<Usuario> usuarios = _context.Usuarios.ToList();

            if (usuarios == null || usuarios.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios en la base de datos.");
            }
            else
            {
                Console.WriteLine($"Usuarios encontrados: {usuarios.Count}");
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Usuarios");

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Nombre";
                worksheet.Cells[1, 3].Value = "Email";

                for (int i = 0; i < usuarios.Count; i++)
                {
                    worksheet.Cells[i.ToString()].Value = usuarios[i].IdUsuarios;
                    worksheet.Cells[i.ToString()].Value = usuarios[i].NombreUsuario;
                    worksheet.Cells[i.ToString()].Value = usuarios[i].Email;
                }

                worksheet.Cells.AutoFitColumns();
                var excelBytes = package.GetAsByteArray();
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Usuarios.xlsx");
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
    }
}
