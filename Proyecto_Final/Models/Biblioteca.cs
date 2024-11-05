using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models;

public partial class Biblioteca
{
    [Key]
    public int IdBiblio { get; set; }

    public string Nombre { get; set; }

    public int? Juegos { get; set; }

    public virtual Juego JuegosNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
