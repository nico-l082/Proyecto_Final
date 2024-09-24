using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models.Clases;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int Miembro { get; set; }

    public int CantJuegos { get; set; }

    public int BiblioJuegos { get; set; }

    public virtual Biblioteca BiblioJuegosNavigation { get; set; } = null!;

    public virtual MiembrosPlu MiembroNavigation { get; set; } = null!;
}
