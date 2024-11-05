using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models.Clases;

public partial class MiembrosPlu
{
    [Key]
    public int IdMiembros { get; set; }

    public int Tipo { get; set; }

    public decimal PrecioMembresia { get; set; }

    public string FormaPago { get; set; } = null!;

    public int CantidadJuegosMembresia { get; set; }

    public DateTime Vigencia { get; set; }

    public virtual TipoMembresium TipoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
