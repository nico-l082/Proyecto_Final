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

    public class UsuariosController : Controller
    {
        private readonly ProyectoFinalContext db;

        public UsuariosController(ProyectoFinalContext context)
        {
            db = context;
        }

        // Acción para listar los usuarios
        public IActionResult Index()
        {
            var usuarios = db.Usuarios.ToList(); // Asegúrate de que esto obtiene correctamente los usuarios
            return View(usuarios); // Pasa la lista de usuarios a la vista
        }

        // Acción para eliminar un usuario
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
