using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Models.Clases;

public partial class Usuario
{
    
    public int IdUsuarios { get; set; }

    [Display (Name = "Nombre de usuario")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public string NombreUsuario { get; set; } = null!;

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Email { get; set; } = null!;

    [Display (Name = "contraseña")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Contraseña { get; set; } = null!;
    [NotMapped]
    public int Miembro { get; set; }
    [NotMapped]
    public int CantJuegos { get; set; }
    [NotMapped]
    public int BiblioJuegos { get; set; }
    [NotMapped]
    public virtual Biblioteca BiblioJuegosNavigation { get; set; } = null!;
    [NotMapped]
    public virtual MiembrosPlu MiembroNavigation { get; set; } = null!;
}
