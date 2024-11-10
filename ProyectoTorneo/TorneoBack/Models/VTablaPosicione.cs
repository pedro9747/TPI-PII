using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VTablaPosicione
{
    public string? Equipo { get; set; }

    public int? PartidosJugados { get; set; }

    public int? PartidosGanados { get; set; }

    public int? PartidosEmpatados { get; set; }

    public int? PartidosPerdidos { get; set; }

    public int? DiferenciaGoles { get; set; }

    public int? Puntos { get; set; }
}
