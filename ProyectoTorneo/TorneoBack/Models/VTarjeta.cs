using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VTarjeta
{
    public int? IdJugador { get; set; }

    public string? Jugador { get; set; }

    public string? Equipo { get; set; }

    public int? TarjetasAmarillas { get; set; }

    public int? TarjetasRojas { get; set; }
}
