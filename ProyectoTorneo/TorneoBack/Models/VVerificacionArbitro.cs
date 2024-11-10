using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VVerificacionArbitro
{
    public int IdDelArbitro { get; set; }

    public string? Arbitro { get; set; }

    public int IdDelEquipo { get; set; }

    public string? Equipo { get; set; }

    public string? CiudadDelArbitro { get; set; }

    public string? CiudadDelEquipo { get; set; }

    public int? CantidadDeVecesQueElÁrbitroEstuvoConEsteEquipo { get; set; }
}
