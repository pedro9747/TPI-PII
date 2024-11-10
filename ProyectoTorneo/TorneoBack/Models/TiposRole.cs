using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class TiposRole
{
    public int IdTipoRol { get; set; }

    public string Descripción { get; set; } = null!;

    public virtual ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
}
