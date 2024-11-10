using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class Goleadore
{
    public int? IdJugador { get; set; }

    public string? Jugador { get; set; }

    public string? Equipo { get; set; }

    public int? GolesMarcados { get; set; }
}
