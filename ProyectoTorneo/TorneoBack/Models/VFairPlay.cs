using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VFairPlay
{
    public int IdEquipo { get; set; }

    public string? NombreEquipo { get; set; }

    public int? TotalTarjetasAmarillas { get; set; }

    public int? TotalTarjetasRojas { get; set; }

    public int? TotalTarjetas { get; set; }

    public int? Puntaje { get; set; }
}
