using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models.Clases;

public partial class Membresium
{
    [Key]
    public int IdMembresia { get; set; }

    public string Nombre { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public int TipoMembresia { get; set; }

    public virtual ICollection<TipoMembresium> TipoMembresiaNavigation { get; set; } = new List<TipoMembresium>();
}
