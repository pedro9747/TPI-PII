using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class PosicionesJuego
{
    public int IdPosicion { get; set; }

    public string? Posicion { get; set; }

    public virtual ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
}
