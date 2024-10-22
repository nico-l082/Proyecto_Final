using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class TipoMembresium
{
    public int IdTipoMembresia { get; set; }

    public int? Tipo { get; set; }

    public virtual ICollection<Juego> Juegos { get; set; } = new List<Juego>();

    public virtual ICollection<MiembrosPlu> MiembrosPlus { get; set; } = new List<MiembrosPlu>();

    public virtual Membresium? TipoNavigation { get; set; }
}
