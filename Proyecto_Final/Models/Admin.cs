using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models;

public partial class Admin
{
    [Key]
    public int IdAdmin { get; set; }

    public string Nombre { get; set; }

    public string Email { get; set; }

    public string Contraseña { get; set; }
}
