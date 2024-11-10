using System;
using System.Collections.Generic;

namespace TorneoApi.Models;

public partial class VEvaluacionesArbitro
{
    public int? IdArbitro { get; set; }

    public string? Arbitro { get; set; }

    public int? PuntajePromedio { get; set; }
}
