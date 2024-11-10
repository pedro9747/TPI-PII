using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VGolesRecibido
{
    public int IdEquipo { get; set; }

    public string? Equipo { get; set; }

    public int? GolesRecibidosComoLocal { get; set; }

    public int? GolesRecibidosComoVisitante { get; set; }

    public int? TotalGolesRecibidos { get; set; }
}
