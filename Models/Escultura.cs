using System;
using System.Collections.Generic;

namespace API2.Models;

public partial class Escultura
{
    public int Id { get; set; }

    public string NombreEscultura { get; set; } = null!;

    public string Precio { get; set; }

    public bool Vendido { get; set; }

    public string? Historia { get; set; }

    public string Imagen { get; set; } = null!;

    public string Ancho { get; set; }

    public string Alto { get; set; } 
}