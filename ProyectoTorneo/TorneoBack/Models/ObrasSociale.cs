using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class ObrasSociale
{
    public int IdObraSocial { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Calle { get; set; }

    public int? Altura { get; set; }

    public virtual ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
}
