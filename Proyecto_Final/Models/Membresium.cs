using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class Membresium
{
    public int IdMembresia { get; set; }

    public string Nombre { get; set; }

    public string Detalle { get; set; }

    public int? TipoMembresia { get; set; }

    public virtual ICollection<TipoMembresium> TipoMembresiaNavigation { get; set; } = new List<TipoMembresium>();
}
