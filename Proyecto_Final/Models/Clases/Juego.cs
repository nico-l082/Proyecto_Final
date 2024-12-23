﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Models.Clases;

public partial class Juego
{
    [Key]
    public int IdJuegos { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int ItiPlus { get; set; }

    public decimal Precio { get; set; }

    public string Desarrolladora { get; set; } = null!;
    [NotMapped]
    public string ImagenUrl { get; set; } = null!;

    public virtual ICollection<Biblioteca> Bibliotecas { get; set; } = new List<Biblioteca>();

    public virtual TipoMembresium ItiPlusNavigation { get; set; } = null!;
}
