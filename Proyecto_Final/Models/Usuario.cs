using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string NombreUsuario { get; set; }

    public string Email { get; set; }

    public string Contraseña { get; set; }

    public int? Miembro { get; set; }

    public int? CantJuegos { get; set; }

    public int? BiblioJuegos { get; set; }

    public virtual Biblioteca BiblioJuegosNavigation { get; set; }

    public virtual MiembrosPlu MiembroNavigation { get; set; }
}
