using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models.Clases;

public partial class Biblioteca
{
    public int IdBiblio { get; set; }

    public string Nombre { get; set; } = null!;

    public int Juegos { get; set; }

    public virtual Juego JuegosNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
