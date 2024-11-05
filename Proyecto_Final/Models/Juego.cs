﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models;

public partial class Juego
{
    [Key]
    public int IdJuegos { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public string Genero { get; set; }

    public int? ItiPlus { get; set; }

    public decimal? Precio { get; set; }
   
    public string Desarrolladora { get; set; }

    public string ImagenUrl { get; set; }

    public virtual ICollection<Biblioteca> Bibliotecas { get; set; } = new List<Biblioteca>();

    public virtual TipoMembresium ItiPlusNavigation { get; set; }
}
