using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class UsuarioJuego
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int JuegoId { get; set; }

    public DateTime FechaCompra { get; set; }

    public virtual Juego Juego { get; set; }

    public virtual Usuario User { get; set; }
}
