using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Models;

public partial class UsuarioJuego
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Usuario")]
    public int UserId { get; set; }
    [ForeignKey("Juego")]
    public int JuegoId { get; set; }

    public DateTime FechaCompra { get; set; }

    public virtual Juego Juego { get; set; }

    public virtual Usuario User { get; set; }
}
