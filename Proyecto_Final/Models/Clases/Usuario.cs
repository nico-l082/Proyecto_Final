using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models.Clases;

public partial class Usuario
{
    
    public int IdUsuarios { get; set; }

    [Display (Name = "Nombre de usuario")]
    [Required]
    public string NombreUsuario { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;

    [Display (Name = "contraseña")]
    [Required]
    public string Contraseña { get; set; } = null!;

    public int Miembro { get; set; }

    public int CantJuegos { get; set; }

    public int BiblioJuegos { get; set; }

    public virtual Biblioteca BiblioJuegosNavigation { get; set; } = null!;

    public virtual MiembrosPlu MiembroNavigation { get; set; } = null!;
}
