using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VRendimientoJugadore
{
    public int IdJugador { get; set; }

    public string? Jugador { get; set; }

    public string? Equipo { get; set; }

    public int? PartidosJugados { get; set; }

    public int? Goles { get; set; }

    public int? Asistencias { get; set; }

    public int? TarjetasAmarillas { get; set; }

    public int? TarjetasRojas { get; set; }
}
