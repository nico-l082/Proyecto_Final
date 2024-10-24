using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string Nombre { get; set; }

    public string Email { get; set; }

    public string Contraseña { get; set; }
}
