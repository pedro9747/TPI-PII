using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VResultadoPartido
{
    public int IdPartido { get; set; }

    public string? Equipo1 { get; set; }

    public string? Equipo2 { get; set; }

    public int? GolesEquipo1 { get; set; }

    public int? GolesEquipo2 { get; set; }

    public string? Resultado { get; set; }
}
