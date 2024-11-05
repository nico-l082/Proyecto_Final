using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models.Clases;

public partial class TipoMembresium
{
    [Key]
    public int IdTipoMembresia { get; set; }

    public int Tipo { get; set; }

    public virtual ICollection<Juego> Juegos { get; set; } = new List<Juego>();

    public virtual ICollection<MiembrosPlu> MiembrosPlus { get; set; } = new List<MiembrosPlu>();

    public virtual Membresium TipoNavigation { get; set; } = null!;
}
